using Dictionary.Domain.Data.Entity;
using Dictionary.Domain.Data.Entity.Enum;
using Dictionary.Domain.Data.Repositories.Contract;
using Dictionary.Domain.Exception;
using Dictionary.Web.Infrastructure.Extensions;
using Dictionary.Web.Models.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Dictionary.Web.Infrastructure.Authorization
{
    public class SignInManager : ISignInManager
    {
        private readonly IUserRepository _userRepository;
        private readonly HttpContext _httpContext;
        private ClaimsPrincipal _user;

        public SignInManager(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _httpContext = httpContextAccessor.HttpContext;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<bool> HasActiveSessionsAsync()
        {
            if(await _userRepository.GetByIdAsync(_user.GetId()) is { } user)
            {
                return user.ActiveSessions.Count > 0;
            }

            return false;
        }

        public async Task SignInByPasswordAsync(SignInRequest request)
        {
            if (_user.Identity.IsAuthenticated)
            {
                return;
            }

            var user = _userRepository.List().FirstOrDefault(userIdentity => 
            userIdentity.Login == request.Login && 
            userIdentity.Password == request.Password);

            if (user is not null) 
            {
                _user = CreateClaimsPrincipal(user);

                user.CloseActiveSessions();
                user.CreateSession();

                _userRepository.Update(user);

                await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, _user);
            }

            if (!_user.Identity.IsAuthenticated)
            {
                throw new UnprocessableEntityApplicationException("Ошибка аутентификации");
            }
        }

        private static ClaimsPrincipal CreateClaimsPrincipal(User user) =>
            GetClaimsPrincipal(user.Id.ToString(), user.RoleId);

        private static ClaimsPrincipal GetClaimsPrincipal(string userId, RoleType userRoleType)
        {
            var claims = new List<Claim>()
            {
                new Claim("UserId", userId),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoleType.ToString())
            };

            return new(new ClaimsIdentity(
                claims,
                "UPATechnologicalConnection",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType));
        }

        public async Task SignOutAsync()
        {
            if (!_user.Identity.IsAuthenticated)
            {
                return;
            }

            if(_userRepository.GetById(_user.GetId()) is { } user)
            {
                user.CloseActiveSessions();

                _userRepository.Update(user);
            }

            await _httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
