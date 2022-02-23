namespace PrivateNotes.Pages
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class AuthorizationModel : PageModel
    {
        private readonly ILogger<AuthorizationModel> _logger;

        public AuthorizationModel(ILogger<AuthorizationModel> logger)
        {
            _logger = logger;
        }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public void OnGet()
        {
        }
    }
}
