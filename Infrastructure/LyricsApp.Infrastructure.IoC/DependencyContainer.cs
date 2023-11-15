using LyricsApp.Core.Entities.Data;
using LyricsApp.Infrastructure.EFCore.DataContext.Context;
using LyricsApp.Infrastructure.EFCore.DataContext.Repositories;
using LyricsApp.Songs.Repositories;
using LyricsApp.Firebase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<ISongRepository, SongRepository>();
            
            services.AddFirebaseService();

            return services;
        }

    }

}
