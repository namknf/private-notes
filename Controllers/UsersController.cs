namespace CustomIdentityApp.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PrivateNotes;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Services;
    using BCryptNet = BCrypt.Net.BCrypt;

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthorizeRequest model)
        {
            var response = _userService.Authorize(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Account userModel)
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
