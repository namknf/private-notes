namespace PrivateNotes.Services
{
    using System.Threading.Tasks;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;

    public interface INoteService
    {
        Task<NoteResponse> Create(CreateNoteModel note, User user);
    }
}
