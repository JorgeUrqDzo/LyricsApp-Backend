namespace LyricsApp.Users.Services
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(string email, string password, string name);
    }

}