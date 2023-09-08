using Dictionary.Domain.Exception;
using Dictionary.Web.Infrastructure.Authorization;
using Dictionary.Web.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Web.Controllers
{
    [Route("api/authorization")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ISignInManager _signInManager;

        public AuthorizationController(ISignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        ///     Получение информации об аутентификации пользователя.
        ///     Доступно всем.
        /// </summary>
        [HttpGet("is-authenticated")]
        [AllowAnonymous]
        public ActionResult<bool> IsAuthenticated() => Ok(User.Identity.IsAuthenticated);

        /// <summary>
        ///     Аутентификация и авторизация пользователя.
        ///     Доступно всем.
        /// </summary>
        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignInAsync([FromBody]SignInRequest request)
        {
            try
            {
                await _signInManager.SignInByPasswordAsync(request);

                return NoContent();
            }
            catch (UnprocessableEntityApplicationException exception)
            {
                return UnprocessableEntity(exception.Message);
            }
        }
    }
}
