namespace PrivateNotes.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Services.Note;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    [Authorize]
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
        
        public IActionResult CreateNote()
        {
            return View();
        }

        [HttpPost("create")]
        [Authorize(Policy = "Authorized")]
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

        [HttpGet]
        public Task<IActionResult> GetNotes()
        {
            var notes = _noteService.GetAll();
            return Task.FromResult<IActionResult>(Json(notes));
        }
    }
}
