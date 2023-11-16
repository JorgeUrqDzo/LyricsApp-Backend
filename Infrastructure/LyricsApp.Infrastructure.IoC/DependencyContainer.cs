using LyricsApp.Core.Entities.Data;
using LyricsApp.Infrastructure.EFCore.DataContext.Context;
using LyricsApp.Infrastructure.EFCore.DataContext.Repositories;
using LyricsApp.Songs.Repositories;
using LyricsApp.Supabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LyricsApp.Infrastructure.IoC
{

    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            string? connectionEntry)
        {

            if (string.IsNullOrEmpty(connectionEntry))
            {
                throw new ArgumentNullException(nameof(connectionEntry));
            }


            services.AddDbContext<LyricsAppDbContext>(options => options.UseNpgsql(connectionEntry));

            services.AddScoped<ILogWritableRepository,
                LogWritableRepository>();


            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["Authentication:Audience"],
                    ValidIssuer = configuration["Authentication:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Authentication:IssuerSigningKey"]!)
                    ),
                };
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISongRepository, SongRepository>();

            services.AddSupabaseService(configuration);

            return services;
        }

    }

}
