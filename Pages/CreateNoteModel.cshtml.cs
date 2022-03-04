namespace PrivateNotes.Pages
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using PrivateNotes.Models;

    public class CreateNoteModel : BaseModel
    {
        [Required]
        public string Text { get; set; }

        public DateTime NoteDate { get; set; }

        public int? NoteUserId { get; set; }

        public User NoteUser { get; set; }
    }
}
