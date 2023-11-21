using LyricsApp.Infrastructure.EFCore.DataContext;
using LyricsApp.Supabase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LyricsApp.Auth.Settings;
using LyricsApp.JwtTokenHandler;

namespace LyricsApp.Infrastructure.IoC
{

    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            string? connectionEntry)
        {

            var authenticationSettings = configuration.GetSection("Authentication").Get<AuthenticationSettings>();
            services.AddSingleton(authenticationSettings!);
            services.AddJwtTokenHandler();

            services.AddDataContext(configuration, connectionEntry);


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


            services.AddSupabaseService(configuration);

            return services;
        }

    }

}
