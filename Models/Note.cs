﻿#nullable disable

namespace PrivateNotes.Models
{
    using System;

    /// <summary>
    /// Note1 model.
    /// </summary>
    public partial class Note
    {
        public int Id { get; set; }

        public DateTime NoteDate { get; set; }

        public string Text { get; set; }

        public int? NoteUserId { get; set; }

        public virtual User NoteUser { get; set; }
    }
}
