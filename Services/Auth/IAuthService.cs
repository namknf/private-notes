namespace PrivateNotes.Services.Auth
{
    using System.Threading.Tasks;
    using PrivateNotes.Models;
    using PrivateNotes.Pages;

    public interface IAuthService
    {
        AuthorizeResponse Authenticate(AuthorizationModel model);

        Task<AuthorizeResponse> Register(RegistrationModel userModel);

        User GetById(string id);
    }
}
