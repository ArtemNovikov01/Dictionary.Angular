using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Web.Models.Request;
using Dictionary.Web.Models.Views;
using System.Security.Claims;

namespace Dictionary.Web.Infrastructure.Authorization
{
    public interface ISignInManager
    {
        Task<bool> HasActiveSessionsAsync();
        UserIdentityModel GetIdentity(int requesterId);
        Task SignInByPasswordAsync(SignInRequest request);
        Task SignOutAsync();
    }
}
