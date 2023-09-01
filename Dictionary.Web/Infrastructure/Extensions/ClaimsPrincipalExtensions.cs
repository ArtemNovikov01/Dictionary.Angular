using System.Security.Claims;
using System;

namespace Dictionary.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirstValue("UserId"));
        }
    }
}
