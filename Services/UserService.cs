namespace PrivateNotes.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using PrivateNotes.Helpers;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;
    using PrivateNotes.Services.Repositories;

    internal class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IUserRepository<User> userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public AuthorizeResponse Authenticate(AuthorizationModel model)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(x => x.Email == model.Email);

            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

                var isValidPassword = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

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

            var addedUser = await _userRepository.Add(user);

            var response = Authenticate(new AuthorizationModel
            {
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
            });

            return response;
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
