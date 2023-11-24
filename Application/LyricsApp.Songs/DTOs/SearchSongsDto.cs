using LyricsApp.Songs.DTOs;

namespace LyricsApp.Songs
{
    public record SearchSongsDto(Guid? Id, string Title, GenreDto? Genre);
}

