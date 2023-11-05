using System;
using LyricsApp.Core.Entities.Entities;

namespace LyricsApp.Core.Entities.Data
{
    public interface ILogWritableRepository
    {
        void Add(Log log);
        void Add(string description);
    }
}

