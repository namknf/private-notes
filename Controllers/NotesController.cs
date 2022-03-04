namespace PrivateNotes.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Services;
    using PrivateNotes.Services.Repositories;

    [ApiController]
    [Route("notes")]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly UserManager<User> _userManager;
        private readonly NoteRepository<Note> _noteRepository;

        public NotesController(INoteService userService, UserManager<User> userManager, NoteRepository<Note> noteRepository)
        {
            _noteService = userService;
            _userManager = userManager;
            _noteRepository = noteRepository;
        }

        [Authorize]
        public IActionResult CreateNote()
        {
            return View();
        }

        [HttpPost("create")]
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
