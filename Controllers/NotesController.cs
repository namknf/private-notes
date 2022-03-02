namespace PrivateNotes.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PrivateNotes.Pages;
    using PrivateNotes.Services;

    [ApiController]
    [Route("notes")]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService userService)
        {
            _noteService = userService;
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] CreateNoteModel model)
        {
            //var response = _noteService.Create(model);

            //if (response == null)
            //{
            //    return BadRequest(new { message = "Username or password is incorrect" });
            //}

            return Redirect("~/");
        }
    }
}
