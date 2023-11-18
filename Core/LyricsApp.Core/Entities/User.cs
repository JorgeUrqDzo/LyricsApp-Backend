using System.Text.RegularExpressions;

namespace LyricsApp.Core.Entities.Entities
{
    public class User
    {
        private User()
        {

        }

        public User(Guid id, string authId, string email, string displayName)
        {
            Id = id;
            AuthId = authId;
            Email = email;
            DisplayName = displayName;
        }

        public Guid Id { get; private set; }
        public string AuthId { get; private set; }
        public string Email { get; private set; }
        public string DisplayName { get; private set; }
        public Guid? RoleId { get; private set; }

        public Role? Role { get; private set; }
        // public ICollection<Song>? Songs { get; private set; }
        // public ICollection<Playlist>? Playlists { get; private set; }
        // public ICollection<Group>? Groups { get; private set; }
    }
}