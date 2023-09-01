using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Web.Models.Request;
using System.Security.Claims;

namespace Dictionary.Web.Infrastructure.Authorization
{
    public interface ISignInManager
    {
        Task SignInByPasswordAsync(SignInRequest request);
        Task SignOutAsync();
    }
}
