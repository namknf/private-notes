namespace PrivateNotes.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Services;

    [ApiController]
    [Route("notes")]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly UserManager<User> _userManager;

        public NotesController(INoteService userService, UserManager<User> userManager)
        {
            _noteService = userService;
            _userManager = userManager;
        }

        [Authorize(Roles = "authorized")]
        public IActionResult CreateNote()
        {
            return View();
        }

        [HttpPost("create")]
        [Authorize(Roles = "authorized")]
        public async Task<IActionResult> Create([FromBody] CreateNoteModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            var response = _noteService.Create(model, user);

            if (response == null)
            {
                return BadRequest(new { message = "Something went wrong..." });
            }

            return Ok();
        }
    }
}
