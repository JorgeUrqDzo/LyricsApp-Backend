using FirebaseAdmin.Auth;
using LyricsApp.Users.Services;

namespace LyricsApp.Firebase
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<string> RegisterAsync(string email, string password, string name)
        {
            try
            {
                
                var userArgs = new UserRecordArgs 
                {
                    Email = email,
                    Password = password 
                };
                
                var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
    
                return userRecord.Uid;
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
        }
    }
}