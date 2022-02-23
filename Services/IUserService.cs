namespace PrivateNotes.Services
{
    using System.Threading.Tasks;
    using PrivateNotes.Models;

    public interface IUserService
    {
        AuthorizeResponse Authorize(AuthorizeRequest model);

        Task<AuthorizeResponse> Register(Account newUser);

        User GetById(int id);
    }
}
