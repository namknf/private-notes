#nullable disable

namespace PrivateNotes.Models
{
    using System;

    /// <summary>
    /// Account model.
    /// </summary>
    public partial class Account : BaseModel
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }
    }
}
