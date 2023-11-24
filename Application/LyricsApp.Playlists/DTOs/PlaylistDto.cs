namespace LyricsApp.Playlists.DTOs
{
    public class PlaylistDto
    {
        public PlaylistDto(Guid id, string title, int totalSongs)
        {
            Id = id;
            Title = title;
            TotalSongs = totalSongs;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int TotalSongs { get; set; }
    }
}