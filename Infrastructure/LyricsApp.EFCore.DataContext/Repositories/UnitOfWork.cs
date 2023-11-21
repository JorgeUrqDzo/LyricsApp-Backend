using System;
using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Exceptions;
using LyricsApp.Infrastructure.EFCore.DataContext.Context;
using Microsoft.EntityFrameworkCore;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LyricsAppDbContext context;

        public UnitOfWork(LyricsAppDbContext context)
        {
            this.context = context;
        }

        public async ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            int Result;
            try
            {
                Result = await context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                throw new UpdateException(ex.InnerException?.Message ?? ex.Message, ex.Entries.Select(e => e.Entity.GetType().Name).ToList());
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex.Message);
            }

            return Result;
        }
    }
}

