namespace PrivateNotes.Pages
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class RegistrationModel : IdentityUser<int>
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public override string Email { get; set; }

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
