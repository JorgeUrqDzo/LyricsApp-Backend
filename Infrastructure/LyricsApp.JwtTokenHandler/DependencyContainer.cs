using LyricsApp.Auth.Services;

using Microsoft.Extensions.DependencyInjection;

namespace LyricsApp.JwtTokenHandler
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddJwtTokenHandler(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGeneratorService, JwtTokenGenerator>();
            return services;
        }
    }
}