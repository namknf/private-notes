#nullable disable

namespace PrivateNotes.Models
{
    using System;

    /// <summary>
    /// Note model.
    /// </summary>
    public partial class Note
    {
        public int NoteId { get; set; }

        public DateTime NoteDate { get; set; }

        public string Text { get; set; }
    }
}
