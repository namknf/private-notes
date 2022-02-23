namespace PrivateNotes.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class CreateNoteModel : PageModel
    {
        private readonly ILogger<CreateNoteModel> _logger;

        public CreateNoteModel(ILogger<CreateNoteModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
