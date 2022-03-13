namespace PrivateNotes.Services.Auth
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using PrivateNotes.Data;
    using PrivateNotes.Helpers;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Repositories.Account;
    using BCryptNet = BCrypt.Net.BCrypt;

    internal class AuthService : IAuthService
    {
        private readonly PrivateNotesContext _context;
        private readonly IAccountRepository<User> _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IAccountRepository<User> accountRepository, IConfiguration configuration, IMapper mapper, PrivateNotesContext context)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
        }

        public AuthorizeResponse Authenticate(AuthorizationModel model)
        {
            var user = _accountRepository
                .GetAll()
                .FirstOrDefault(x => x.Email == model.Email);

            if (user != null)
            {
                user.Password = model.Password;

                var isValidPassword = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);

                if (isValidPassword)
                {
                    var token = _configuration.GenerateJwtToken(user);

                    return new AuthorizeResponse(user, token);
                }
            }

            return null;
        }

        public async Task<AuthorizeResponse> Register(RegistrationModel userModel)
        {
            var user = _mapper.Map<User>(userModel);

            if (_context.Users.Any(x => x.Email == userModel.Email))
            {
                throw new ArgumentException("Email '" + userModel.Email + "' is already taken");
            }

            user.PasswordHash = BCryptNet.HashPassword(userModel.Password);

            var addedUser = await _accountRepository.Add(user);

            var response = Authenticate(new AuthorizationModel
            {
                Email = user.Email,
                Password = user.Password,
            });

            return response;
        }

        public User GetById(string id)
        {
            return _accountRepository.GetById(id);
        }
    }
}
