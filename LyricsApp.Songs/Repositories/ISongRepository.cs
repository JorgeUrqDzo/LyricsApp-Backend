using LyricsApp.Core.Entities.Entities;

namespace LyricsApp.Songs.Repositories
{
    public interface ISongRepository
    {
        Task CreateSongAsync(Song song);
        Task<Song?> GetSongByIdAsync(Guid id);
        Task<IEnumerable<Song>> GetSongsByUserAsync(Guid userId);
        void Update(Song currentSong);
        void Delete(Song song);
        Task<Song?> FindSongById(Guid id);
    }
}

