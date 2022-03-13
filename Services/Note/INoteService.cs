using System.Collections.Generic;

namespace PrivateNotes.Services.Note
{
    using System.Threading.Tasks;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;

    public interface INoteService
    {
        Task<NoteResponse> Create(CreateNoteModel note, User user);

        Note GetById(int id);

        List<Note> GetAll();
    }
}
