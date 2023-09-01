using Dictionary.Web.Infrastructure.Authorization;
using Dictionary.Web.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Web.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        private readonly ISignInManager _signInManager;

        public AuthorizationController(ISignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignInAsync([FromBody]SignInRequest request)
        {
            try
            {
                await _signInManager.SignInByPasswordAsync(request);

                return NoContent();
            }
            catch (Exception exception) 
            {
                return BadRequest(exception.ToString());
            }
        }
    }
}
