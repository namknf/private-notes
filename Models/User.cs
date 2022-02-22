using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateNotes.Models
{
    public class User
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public string PasswordHash { get; init; }
    }
}
