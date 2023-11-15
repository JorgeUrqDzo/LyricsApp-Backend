using LyricsApp.Core.Entities;
using LyricsApp.Core.Entities.Entities;
using LyricsApp.Infrastructure.EFCore.DataContext.Context;
using LyricsApp.Infrastructure.EFCore.DataContext.Extensions;
using LyricsApp.Songs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly LyricsAppDbContext context;

        public SongRepository(LyricsAppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateSongAsync(Song song)
        {
            await context.Songs.AddAsync(song);
        }

        public void Delete(Song song)
        {
            context.Songs.Remove(song);
        }

        public async Task<Song?> FindSongById(Guid id)
        {
            return await context.Songs.FindAsync(id);
        }

        public async Task<Song?> GetSongByIdAsync(Guid id)
        {
            return await context.Songs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public PagedResult<Song> GetSongsByUserAsync(Guid userId, string query, int page, OrderDirectionEnum order)
        {

            var songs = context.Songs
                .Where(x =>
                    x.Title.ToLower().Contains(query.ToLower()) ||
                    x.Lyric.ToLower().Contains(query.ToLower())
                );

            songs = order == OrderDirectionEnum.ASC ? songs.OrderBy(x => x.Title) : songs.OrderByDescending(x => x.Title);

            return songs.GetPaged(page, context.PAGE_SIZE);
        }

        public async Task<ICollection<Song>> SearchSongsByTitle(string query)
        {
            return await context.Songs
            .Where(x => x.Title.ToLower().Contains(query.ToLower()))
            .OrderBy(x => x.Title)
            .Take(10)
            .ToListAsync();
        }

        public void Update(Song currentSong)
        {
            context.Songs.Update(currentSong);
        }
    }
}

