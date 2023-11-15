using Microsoft.Extensions.DependencyInjection;

namespace LyricsApp.Users;

public static class DependencyContainer
{
    public static IServiceCollection AddLyricsUsers(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyContainer).Assembly);
        });
        
        return services;
    }
}
