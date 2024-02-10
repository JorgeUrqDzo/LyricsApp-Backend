namespace LyricsApp.Songs.DTOs
{
    public record SongDto(Guid? Id, string Title, string Lyric, GenreDto? Genre, bool IsFavorite);
}