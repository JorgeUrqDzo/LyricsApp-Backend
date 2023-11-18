using LyricsApp.Auth.DTOs;

namespace LyricsApp.Auth.Services
{
    public interface IAuthenticationService
    {
        Task<AuthResponse> RegisterAsync(string email, string password, CancellationToken cancellationToken);
        Task<AuthResponse> EmailPasswordSignIn(string email, string password, CancellationToken cancellationToken);
        Task<AuthResponse> GoogleSignInAsync(string idToken, string accessToken, CancellationToken cancellationToken);
    }

}