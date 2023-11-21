using LyricsApp.Core.Entities.Entities;

namespace LyricsApp.Users.Repositories
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user, CancellationToken cancellationToken);
        Task<User?> FindUserByEmail(string email, CancellationToken cancellationToken);
    }
}