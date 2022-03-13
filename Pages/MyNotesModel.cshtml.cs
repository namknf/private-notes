namespace PrivateNotes.Pages
{
    using PrivateNotes.Models;
    using System.ComponentModel.DataAnnotations;

    public class MyNotesModel : BaseModel
    {
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string Date { get; set; }
    }
}
