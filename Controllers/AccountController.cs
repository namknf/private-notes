namespace PrivateNotes.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PrivateNotes.Pages;
    using PrivateNotes.Services.Auth;

    [ApiController]
    [Authorize]
    [Route("users")]
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromForm] AuthorizationModel model)
        {
            var response = _authService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Redirect("~/");
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegistrationModel userModel)
        {
            var response = await _authService.Register(userModel);

            if (response == null)
            {
                return BadRequest(new { message = "Didn't register!" });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userModel.Email),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return Redirect("~/");
        }

        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("~/");
        }
    }
}
