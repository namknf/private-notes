#nullable disable

namespace PrivateNotes.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// User model.
    /// </summary>
    public partial class User : BaseModel
    {
        public User()
        {
            Notes = new HashSet<Note1>();
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public DateTime RegisterDate { get; set; }

        public string Token { get; set; }

        public virtual ICollection<Note1> Notes { get; set; }
    }
}
