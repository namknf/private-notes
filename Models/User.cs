#nullable disable

namespace PrivateNotes.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// User model.
    /// </summary>
    public sealed partial class User : IdentityUser<int>
    {
        public User()
        {
            Notes = new HashSet<Note>();
        }

        public override string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public ICollection<Note> Notes { get; set; }
    }

    public class AppRole : IdentityRole<int>
    {
    }
}