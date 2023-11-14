namespace LyricsApp.Core.Entities { }

public class Playlist
{
    private Playlist() { }

    public Playlist(Guid id, string title, Guid owner)
    {
        Id = id;
        Title = title;
        Owner = owner;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Guid Owner { get; private set; }

    public ICollection<PlaylistSong> Songs { get; private set; }
}
