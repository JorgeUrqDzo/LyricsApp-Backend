using System;
using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Entities;
using LyricsApp.Infrastructure.EFCore.DataContext.Context;

namespace LyricsApp.Infrastructure.EFCore.DataContext.Repositories
{
    public class LogWritableRepository : ILogWritableRepository
    {
        private readonly LyricsAppDbContext context;

        public LogWritableRepository(LyricsAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Log log)
        {
            context.Add(log);
        }

        public void Add(string description)
        {
            Add(new Log(description));
        }
    }
}

