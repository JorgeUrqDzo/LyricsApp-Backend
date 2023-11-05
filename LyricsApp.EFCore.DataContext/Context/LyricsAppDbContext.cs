using LyricsApp.Core.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Context
{
    public class LyricsAppDbContext : DbContext
    {
        public LyricsAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}

