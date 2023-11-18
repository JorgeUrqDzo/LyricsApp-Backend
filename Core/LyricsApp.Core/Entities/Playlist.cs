namespace LyricsApp.Core.Entities { }

public class Playlist
{
    private Playlist() { }

    public Playlist(Guid id, string title, Guid ownerId)
    {
        Id = id;
        Title = title;
        OwnerId = ownerId;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Guid OwnerId { get; private set; }

    public ICollection<PlaylistSong> Songs { get; private set; }
}
