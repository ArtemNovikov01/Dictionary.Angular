using Dictionary.Web.Handlers.Contracts;
using Dictionary.Web.Models.Previews;
using Dictionary.Web.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dictionary.Web.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _userHandler;
        public UserController(IUserHandler userHandler) 
        {
            _userHandler = userHandler;
        }

        /// <summary>
        ///     Регистрация.
        ///     Доступно всем.
        /// </summary>
        [HttpPost("user")]
        public ActionResult AddUser(AddUserRequest request)
        {
            try
            {
                _userHandler.AddUser(request);

                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        /// <summary>
        ///     Отправление кода подтверждения на почту.
        ///     Доступно всем.
        /// </summary>
        [HttpPost("confirm-email")]
        public async Task<ActionResult<bool>> ConfirmationAsync([FromBody] SendByEmailRequest request)
        {
            try
            {
                return Ok(await _userHandler.SendConfirmationCodeByEmailAsync(request));
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        /// <summary>
        ///     Сопоставление введенного кода подтверждения с тем, который был отправлен на почту.
        ///     Доступно всем.
        /// </summary>
        [HttpPost("match-code")]
        public ActionResult<AttemptInfo> MatchConfirmationCode([FromBody] MatchConfirmationCodeRequest request)
        {
            try
            {
                return Ok(_userHandler.MatchConfirmationCode(request));
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        /// <summary>
        ///     Восстановление пароля пользователя.
        ///     Доступно всем.
        /// </summary>
        [HttpPatch("password-recovery")]
        public ActionResult<AttemptInfo> PassworRecovery([FromBody] PasswordRecoveryRequest request)
        {
            try
            {
                return Ok(_userHandler.PasswordRecovery(request));
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.ToString());
            }
        }
    }
}
