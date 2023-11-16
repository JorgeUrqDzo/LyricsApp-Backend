using LyricsApp.Users.Services;

using Supabase;

namespace LyricsApp.Supabase
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Client _supabaseClient;

        public AuthenticationService(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async Task<string> RegisterAsync(string email, string password, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _supabaseClient.Auth.SignUp(email, password);

                return response?.User?.Id ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}