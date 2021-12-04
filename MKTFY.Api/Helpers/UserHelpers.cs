using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MKTFY.Api.Helpers
{
    /// <summary>
    /// Helpers for the User Entity and it's related code.
    /// </summary>
    public static class UserHelpers
    {
        /// <summary>
        /// Get the Id of a specific entity.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetId(this ClaimsPrincipal principal)
        {
            var userIdClaim = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier) ?? principal.FindFirst(c => c.Type == "sub");
            if (userIdClaim != null && !string.IsNullOrEmpty(userIdClaim.Value))
                return userIdClaim.Value;

            return null;
        }
    }
}
