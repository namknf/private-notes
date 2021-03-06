namespace PrivateNotes.Models
{
    using System.Collections.Generic;

    public sealed class AuthorizeResponse
    {
        public AuthorizeResponse(User model, string token)
        {
            Id = model.Id;
            Email = model.Email;
            Password = model.Password;
            Notes = model.Notes;
            Token = token;
        }

        public string Id { get; init; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}