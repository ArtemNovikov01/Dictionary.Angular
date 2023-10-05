using Dictionary.Domain.Exception;
using Dictionary.Web.Infrastructure.Authorization;
using Dictionary.Web.Infrastructure.Extensions;
using Dictionary.Web.Models.Request;
using Dictionary.Web.Models.Views;
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
        public ActionResult<bool> IsAuthenticated()
        {
           // var a = User.Identity.IsAuthenticated;
            return Ok(User.Identity.IsAuthenticated);
        }

        /// <summary>
        ///     Получение информации об авторизационных данных пользователя.
        ///     Доступно авторизованному пользователю.
        /// </summary>
        [HttpGet("identity")]
        [Authorize]
        public ActionResult<UserIdentityModel> GetIdentity()
        {
            try
            {
                return Ok(_signInManager.GetIdentity(User.GetId()));
            }
            catch (NotFoundApplicationExecption exception)
            {
                return NotFound(exception.ToString());
            }
        }

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

        /// <summary>
        ///     Выход из системы (удаление всех активных сессий пользователя).
        ///     Доступно авторизованному пользователю.
        /// </summary>
        [HttpPost("sign-out")]
        [Authorize]
        public async Task<IActionResult> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }
    }
}
