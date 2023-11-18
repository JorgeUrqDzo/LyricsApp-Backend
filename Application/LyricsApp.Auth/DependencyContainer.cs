using Microsoft.Extensions.DependencyInjection;

namespace LyricsApp.Auth;

public static class DependencyContainer
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyContainer).Assembly);
        });

        return services;
    }
}
