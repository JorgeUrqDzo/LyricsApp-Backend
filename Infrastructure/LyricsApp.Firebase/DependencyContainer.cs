using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using LyricsApp.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LyricsApp.Firebase
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddFirebaseService(this IServiceCollection services)
        {

            FirebaseApp.Create(new AppOptions {
                Credential = GoogleCredential.FromFile("firebase.json")
            });

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            
            return services;
        }
    }

}