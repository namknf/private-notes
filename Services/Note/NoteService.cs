using System.Collections.Generic;

namespace PrivateNotes.Services.Note
{
    using System.Threading.Tasks;
    using AutoMapper;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Repositories.Note;

    public class NoteService : INoteService
    {
        private readonly INoteRepository<Note> _noteRepository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository<Note> noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<NoteResponse> Create(CreateNoteModel model, User user)
        {
            var note = _mapper.Map<Note>(model);

            await _noteRepository.Add(note);

            var response = new NoteResponse(user, model);

            return response;
        }

        public Note GetById(int id)
        {
            return _noteRepository.GetNoteById(id);
        }

        public List<Note> GetAll()
        {
           return _noteRepository.GetAll();
        }
    }
}
