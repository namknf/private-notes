namespace PrivateNotes.Pages
{
    using System.ComponentModel.DataAnnotations;
    using PrivateNotes.Models;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "[AllowAnonymous]")]
    public class AuthorizationModel : BaseModel
    {
        [Required(ErrorMessage = "Email address not specified")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(76, MinimumLength = 8, ErrorMessage = "Password length must be at least 8 characters")]
        public string Password { get; set; }
    }
}
