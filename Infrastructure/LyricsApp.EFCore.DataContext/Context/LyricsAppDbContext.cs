using LyricsApp.Core.Entities;
using LyricsApp.Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Context
{
    public class LyricsAppDbContext : DbContext
    {
        public readonly int PAGE_SIZE = 100;

        public LyricsAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }

    }
}

