namespace PrivateNotes.Pages
{
    using System.ComponentModel.DataAnnotations;
    using PrivateNotes.Models;

    public class AuthorizationModel : BaseModel
    {
        [Required(ErrorMessage = "Email address not specified")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(76, MinimumLength = 8, ErrorMessage = "Password length must be at least 8 characters")]
        public string Password { get; set; }
    }
}
