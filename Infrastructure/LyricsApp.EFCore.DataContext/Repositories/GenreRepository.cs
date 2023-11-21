using LyricsApp.Core.Entities;
using LyricsApp.Genres.Repositories;
using LyricsApp.Infrastructure.EFCore.DataContext.Context;

using Microsoft.EntityFrameworkCore;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LyricsAppDbContext _context;


        public GenreRepository(LyricsAppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Genre genre, CancellationToken cancellationToken)
        {
            await _context.Genres.AddAsync(genre, cancellationToken);
        }

        public async Task<Genre?> GetGenresByIdAsync(Guid ownerId, Guid genreId, CancellationToken cancellationToken)
        {
            return await _context.Genres.FirstOrDefaultAsync(x => x.OwnerId == ownerId && x.Id == genreId, cancellationToken);
        }

        public async Task<ICollection<Genre>> GetGenresByOwnerAsync(Guid ownerId, CancellationToken cancellationToken)
        {
            return await _context.Genres
            .Where(x => x.OwnerId == ownerId)
            .ToListAsync(cancellationToken);
        }

        public void Remove(Genre genre)
        {
            _context.Genres.Remove(genre);
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
        }

    }
}