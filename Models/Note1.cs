using System;

#nullable disable

namespace PrivateNotes
{
    public partial class Note1
    {
        public int Id { get; set; }

        public DateTime NoteDate { get; set; }

        public string Text { get; set; }

        public int? NoteUserId { get; set; }

        public virtual User NoteUser { get; set; }
    }
}
