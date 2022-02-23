namespace PrivateNotes.Services
{
    using PrivateNotes.Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        AuthorizeResponse Authorize(AuthorizeRequest model);

        Task<AuthorizeResponse> Register(Account newUser);
    }
}
