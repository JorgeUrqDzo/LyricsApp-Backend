using LyricsApp.Core.Entities.Entities;

namespace LyricsApp.Users.Repositories
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user, CancellationToken cancellationToken);
        Task<User?> FindUserByAuthId(string authId, CancellationToken cancellationToken);
    }
}