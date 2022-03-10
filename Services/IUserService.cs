namespace PrivateNotes.Services
{
    using System.Threading.Tasks;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;

    public interface IUserService
    {
        AuthorizeResponse Authenticate(AuthorizationModel model);

        Task<AuthorizeResponse> Register(RegistrationModel userModel);

        User GetById(string id);
    }
}
