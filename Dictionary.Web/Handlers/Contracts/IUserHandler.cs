using Dictionary.Web.Mappers.Contracts;
using Dictionary.Web.Models.Previews;
using Dictionary.Web.Models.Request;

namespace Dictionary.Web.Handlers.Contracts
{
    public interface IUserHandler
    {
        void AddUser(AddUserRequest request);
        Task<bool> SendConfirmationCodeByEmailAsync(SendByEmailRequest request);
        AttemptInfo MatchConfirmationCode(MatchConfirmationCodeRequest request);
        AttemptInfo PasswordRecovery(PasswordRecoveryRequest request);


    }
}
