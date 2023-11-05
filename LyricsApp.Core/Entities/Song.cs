using System;
namespace LyricsApp.Core.Entities.Entities
{
    public class Song
    {
        private Song()
        {
        }

        public Song(Guid id, string title, string lyric)
        {
            Id = id;
            Title = title;
            Lyric = lyric;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Lyric { get; set; }

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

