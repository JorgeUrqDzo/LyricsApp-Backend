using LyricsApp.Core.Entities;
using LyricsApp.Core.Entities.Entities;

namespace LyricsApp.Songs.Repositories
{
    public interface ISongRepository
    {
        Task CreateSongAsync(Song song);
        Task<Song?> GetSongByIdAsync(Guid id, Guid ownerId);
        Task<PagedResult<Song>> GetSongsByUserAsync(Guid userId, string query, int page = 1, OrderDirectionEnum order = OrderDirectionEnum.ASC);
        void Update(Song currentSong);
        void Delete(Song song);
        Task<Song?> FindSongById(Guid id, Guid ownerId);
        Task<ICollection<Song>> SearchSongsByTitle(string query, Guid ownerId);
    }
}

