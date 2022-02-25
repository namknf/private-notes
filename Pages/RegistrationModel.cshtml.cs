namespace PrivateNotes.Pages
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Extensions.Logging;
    using PrivateNotes.Models;

    public class RegistrationModel : BaseModel
    {
        private readonly ILogger<RegistrationModel> _logger;

        public RegistrationModel(ILogger<RegistrationModel> logger)
        {
            _logger = logger;
        }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }

        public void OnGet()
        {
        }
    }
}
