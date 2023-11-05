using System;
using LyricsApp.Core.Entities.Entities;
using LyricsApp.Infrastructure.EFCore.DataContext.Context;
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

        public async Task<IEnumerable<Song>> GetSongsByUserAsync(Guid userId)
        {
            return await context.Songs.ToListAsync();
        }

        public void Update(Song currentSong)
        {
            context.Songs.Update(currentSong);
        }
    }
}

