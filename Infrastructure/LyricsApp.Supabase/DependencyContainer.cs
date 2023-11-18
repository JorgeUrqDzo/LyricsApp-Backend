using LyricsApp.Auth.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Supabase;

namespace LyricsApp.Supabase
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddSupabaseService(this IServiceCollection services, IConfiguration configuration)
        {

            var url = configuration["Authentication:SupabaseUrl"];
            var key = configuration["Authentication:SupabaseKey"];
           
            var options = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true,
                // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
            };

            // Note the creation as a singleton.
            services.AddSingleton(provider => new Client(url, key, options));

            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }

}