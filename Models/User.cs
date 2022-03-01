#nullable disable

namespace PrivateNotes.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// User model.
    /// </summary>
    public partial class User : BaseModel
    {
        public User()
        {
            Notes = new HashSet<Note>();
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string Token { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
