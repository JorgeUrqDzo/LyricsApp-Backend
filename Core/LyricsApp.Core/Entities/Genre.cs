using LyricsApp.Core.Entities.Entities;

namespace LyricsApp.Core.Entities;

public class Genre
{
    private Genre() { }

    public Genre(Guid id, string name, Guid ownerId)
    {
        Id = id;
        Name = name;
        OwnerId = ownerId;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid OwnerId { get; private set; }

    public ICollection<Song> Songs { get; set; }

    public void UpdateName(string name)
    {
        if(!string.IsNullOrWhiteSpace(name) && Name != name)
        {
            Name = name;
        }
    }
}
