namespace PrivateNotes.Models
{
    using System;
    using System.Collections.Generic;

    public class AuthorizeResponse
    {
        public AuthorizeResponse(User model, string token)
        {
            Id = model.Id;
            Email = model.Email;
            Password = model.Password;
            PasswordHash = model.PasswordHash;
            Notes = model.Notes;
            Token = token;
        }

        public int Id { get; init; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string Token { get; set; }

        public virtual ICollection<Note1> Notes { get; set; }
    }
}
