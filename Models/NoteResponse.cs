namespace PrivateNotes.Models
{
    using System;

    public class NoteResponse
    {
        public NoteResponse(Note model, User user)
        {
            Id = model.Id;
            NoteDate = model.NoteDate;
            Text = model.Text;
            NoteUserId = model.NoteUserId;
            NoteUser = model.NoteUser;
        }

        public int Id { get; set; }

        public DateTime NoteDate { get; set; }

        public string Text { get; set; }

        public int? NoteUserId { get; set; }

        public virtual User NoteUser { get; set; }
    }
}
