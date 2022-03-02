namespace PrivateNotes.Pages
{
    using System.ComponentModel.DataAnnotations;
    using PrivateNotes.Models;

    public class RegistrationModel : BaseModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(76, MinimumLength = 8, ErrorMessage = "Password length must be at least 8 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [StringLength(76, MinimumLength = 8, ErrorMessage = "Password length must be at least 8 characters")]
        public string PasswordConfirm { get; set; }
    }
}
