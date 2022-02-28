namespace PrivateNotes.Pages
{
    using System.ComponentModel.DataAnnotations;
    using PrivateNotes.Models;

    public class AuthorizationModel : BaseModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
