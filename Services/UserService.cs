namespace PrivateNotes.Services
{
    using System.Threading.Tasks;
    using PrivateNotes.Models;

    public class UserService : IUserService
    {
        public AuthorizeResponse Authorize(AuthorizeRequest model)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<AuthorizeResponse> Register(Account newUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
