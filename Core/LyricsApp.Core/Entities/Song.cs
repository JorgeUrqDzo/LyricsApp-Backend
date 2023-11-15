using System;
namespace LyricsApp.Core.Entities.Entities
{
    public class Song
    {
        private Song()
        {
        }

        public Song(Guid id, string title, string lyric, Guid owner)
        {
            Id = id;
            Title = title;
            Lyric = lyric;
            Owner = owner;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Lyric { get; private set; }
        public Guid Owner { get; private set; }

        public void Update(string title, string lyric)
        {
            if (!Title.Equals(title) && !string.IsNullOrWhiteSpace(title))
            {
                Title = title;
            }

            if (!Lyric.Equals(lyric) && !string.IsNullOrWhiteSpace(lyric))
            {
                Lyric = lyric;
            }
        }
    }
}

