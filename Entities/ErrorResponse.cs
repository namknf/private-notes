namespace PrivateNotes.Entities
{
    using System.Collections.Generic;
    using PrivateNotes.Models;

    public class ErrorResponse
    {
        public List<Error> Errors { get; set; } = new ();
    }
}
