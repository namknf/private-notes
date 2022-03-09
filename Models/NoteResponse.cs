namespace PrivateNotes.Models
{
    using System;
    using PrivateNotes.Pages;

    public sealed class NoteResponse
    {
        public NoteResponse(User user, CreateNoteModel data)
        {
            Id = data.Id;
            NoteDate = data.NoteDate;
            Text = data.Text;
            NoteUserId = data.NoteUserId;
            NoteUser = user;
        }

        public int Id { get; set; }

        public DateTime NoteDate { get; set; }

        public string Text { get; set; }

        public int? NoteUserId { get; set; }

        public User NoteUser { get; set; }
    }
}
