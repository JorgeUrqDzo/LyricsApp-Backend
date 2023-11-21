using LyricsApp.Core.Entities;

namespace LyricsApp.Genres.Repositories
{
    public interface IGenreRepository
    {
        Task CreateAsync(Genre genre, CancellationToken cancellationToken);
        void Update(Genre genre);
        void Remove(Genre genre);
        Task<ICollection<Genre>> GetGenresByOwnerAsync(Guid ownerId, CancellationToken cancellationToken);
        Task<Genre?> GetGenresByIdAsync(Guid ownerId, Guid genreId, CancellationToken cancellationToken);

    }
}