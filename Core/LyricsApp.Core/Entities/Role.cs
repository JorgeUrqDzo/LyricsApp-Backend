namespace LyricsApp.Core.Entities.Entities
{
    public class Role
    {
        private Role()
        {

        }

        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<User>? Users { get; private set; }
    }
}