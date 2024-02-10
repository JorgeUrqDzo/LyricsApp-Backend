using System;
namespace LyricsApp.Core.Entities.Entities
{
    public class Song
    {
        private Song()
        {
        }

        public Song(Guid id, string title, string lyric, Guid ownerId)
        {
            Id = id;
            Title = title;
            Lyric = lyric;
            OwnerId = ownerId;
        }

        public Song(Guid id, string title, string lyric, Guid ownerId, Guid? genreId)
        {
            Id = id;
            Title = title;
            Lyric = lyric;
            OwnerId = ownerId;
            GenreId = genreId;
            IsFavorite = false;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Lyric { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid? GenreId { get; private set; }

        public bool IsFavorite { get; set; }

        public Genre? Genre { get; set; }

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

        public void UpdateGenre(Guid? genreId)
        {
            GenreId = genreId;
        }

        public void SetAsFavorite(bool isFavorite = true)
        {
            IsFavorite = isFavorite;
        }
    }
}

