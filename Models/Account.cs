using System;
using System.Collections.Generic;

#nullable disable

namespace PrivateNotes
{
    public partial class Account
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
