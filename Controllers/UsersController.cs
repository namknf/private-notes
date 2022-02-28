namespace CustomIdentityApp.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Services;
    using BCryptNet = BCrypt.Net.BCrypt;

    [ApiController]
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthorizationModel model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationModel userModel)
        {
            var response = await _userService.Register(userModel);

            if (response == null)
            {
                return BadRequest(new { message = "Didn't register!" });
            }

            return Ok(response);
        }
    }
}
