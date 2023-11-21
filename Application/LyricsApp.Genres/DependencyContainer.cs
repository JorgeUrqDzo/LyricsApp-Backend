using Microsoft.Extensions.DependencyInjection;

namespace LyricsApp.Genres;

public static class DependencyContainer
{
    public static IServiceCollection AddGenres(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyContainer).Assembly);
        });
        
        return services;
    }
}
