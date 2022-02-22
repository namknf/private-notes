using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PrivateNotes.Pages
{
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
