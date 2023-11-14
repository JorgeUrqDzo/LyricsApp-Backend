using LyricsApp.Core.Entities.Entities;

public class PlaylistSong
{
    private PlaylistSong() { }

    public PlaylistSong(Guid id, Guid songId, Guid playlistId)
    {
        Id = id;
        SongId = songId;
        PlaylistId = playlistId;
    }

    public Guid Id { get; private set; }
    public Guid SongId { get; private set; }
    public Guid PlaylistId { get; private set; }

    public Song Song { get; private set; }
    public Playlist Playlist { get; private set; }
}
