namespace PrivateNotes.Pages
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "authorized")]
    public class CreateNoteModel : PageModel
    {
        [Required]
        public string Text { get; set; }

        public DateTime NoteDate { get; set; }

        public int? NoteUserId { get; set; }

        public int Id { get; set; }
    }
}
