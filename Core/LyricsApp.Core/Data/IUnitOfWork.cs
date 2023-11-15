using System;
namespace LyricsApp.Core.Entities.Data
{
    public interface IUnitOfWork
    {
        ValueTask<int> SaveChanges();
    }
}

