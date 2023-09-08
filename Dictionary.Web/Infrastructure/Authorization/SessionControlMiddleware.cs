namespace Dictionary.Web.Infrastructure.Authorization
{
    public class SessionControlMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISignInManager signInManager)
        {
            if (context.User.Identity.IsAuthenticated && !await signInManager.HasActiveSessionsAsync())
            {
                await signInManager.SignOutAsync();

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {
                await _next(context);
            }
        }
    }
}
