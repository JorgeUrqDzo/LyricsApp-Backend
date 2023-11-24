using Microsoft.Extensions.DependencyInjection;

namespace LyricsApp.Playlists;

public static class DependencyContainer
{
    public static IServiceCollection AddPlaylist(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyContainer).Assembly);
        });
        
        return services;
    }

}
