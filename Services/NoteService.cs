namespace PrivateNotes.Services
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Services.Repositories;

    public class NoteService : INoteService
    {
        private readonly INoteRepository<Note> _noteRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;

        public NoteService(INoteRepository<Note> noteRepository, IConfiguration configuration, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<NoteResponse> Create(CreateNoteModel model, User user)
        {
            var note = _mapper.Map<Note>(model);

            var addedUser = await _noteRepository.Add(note);

            var response = new NoteResponse(user, model);

            return response;
        }
    }
}
