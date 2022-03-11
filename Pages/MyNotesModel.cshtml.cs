namespace PrivateNotes.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Roles = "authorized")]
    public class MyNotesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
