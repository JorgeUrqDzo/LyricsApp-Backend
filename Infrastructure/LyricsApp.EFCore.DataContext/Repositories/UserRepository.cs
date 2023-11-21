using LyricsApp.Core.Entities.Entities;
using LyricsApp.Infrastructure.EFCore.DataContext.Context;
using LyricsApp.Users.Repositories;

using Microsoft.EntityFrameworkCore;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LyricsAppDbContext _context;

        public UserRepository(LyricsAppDbContext context)
        {
            _context = context;
        }

        public async Task RegisterUserAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
        }

        public async Task<User?> FindUserByEmail(string email, CancellationToken cancellationToken)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            return result;
        }
    }
}