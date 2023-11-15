using Microsoft.Extensions.DependencyInjection;

namespace LyricsApp.Songs;

public static class DependencyContainer
{
    public static IServiceCollection AddSongs(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyContainer).Assembly);
        });

        return services;
    }
}

