using LyricsApp.Auth.DTOs;
using LyricsApp.Auth.Services;

using SupabaseClient = Supabase;
using SupbaseGotrue = Supabase.Gotrue;


namespace LyricsApp.Supabase
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SupabaseClient.Client _supabaseClient;

        public AuthenticationService(SupabaseClient.Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async Task<AuthResponse> EmailPasswordSignIn(string email, string password, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _supabaseClient.Auth.SignInWithPassword(email, password);
                return new AuthResponse(response?.AccessToken!, response?.RefreshToken!, response?.User?.Id!);
            }
            catch (System.Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }

        public async Task<AuthResponse> GoogleSignInAsync(string idToken, string accessToken, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _supabaseClient.Auth.SignInWithIdToken(provider: SupbaseGotrue.Constants.Provider.Google, idToken, nonce: null, captchaToken: accessToken);
                return new AuthResponse(response?.AccessToken!, response?.RefreshToken!, response?.User?.Id!);
            }
            catch (SupbaseGotrue.Exceptions.GotrueException ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
            catch (System.Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }

        public async Task<AuthResponse> RegisterAsync(string email, string password, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _supabaseClient.Auth.SignUp(email, password);
                return new AuthResponse(response?.AccessToken!, response?.RefreshToken!, response?.User?.Id!);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }

        public async Task SignOut(CancellationToken cancellationToken)
        {
            await _supabaseClient.Auth.SignOut();
        }
    }
}