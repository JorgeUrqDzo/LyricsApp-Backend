namespace LyricsApp.Core.Entities;

public class Genre
{
    private Genre() { }

    public Genre(Guid id, string name, Guid owner)
    {
        Id = id;
        Name = name;
        Owner = owner;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid Owner { get; private set; }
}
