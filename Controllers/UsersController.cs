namespace PrivateNotes.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PrivateNotes.Pages;
    using PrivateNotes.Services;

    [ApiController]
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromForm] AuthorizationModel model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Redirect("~/");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegistrationModel userModel)
        {
            var response = await _userService.Register(userModel);

            if (response == null)
            {
                return BadRequest(new { message = "Didn't register!" });
            }

            return Redirect("~/");
        }
    }
}
