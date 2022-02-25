namespace PrivateNotes.Services
{
    using System.Threading.Tasks;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;

    public interface IUserService
    {
        AuthorizeResponse Authenticate(AuthorizeRequest model);

        Task<AuthorizeResponse> Register(RegistrationModel userModel);

        User GetById(int id);
    }
}
