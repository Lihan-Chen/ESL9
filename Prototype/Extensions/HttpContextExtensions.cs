using Microsoft.Identity.Client;
using System.Security.Claims;

namespace Prototype.Extensions
{
    public static class HttpContextExtensions
    {
        public static String? GetUserIDClaimValue(this HttpContext context)
        {
            return GetStringClaimValue("UserID", context);
        }

        public static int? GetDefaultFacilNoClaimValue(this HttpContext context)
        {
            return GetIntClaimValue("DefaultFacilNo", context);
        }

        public static string? GetRoleClaimValue(this HttpContext context)
        {
            return GetStringClaimValue("Role", context);
        }

        public static bool? GetPrimaryOperatorClaimValue(this HttpContext context)
        {
            return GetBoolClaimValue("PrimaryOperator", context);
        }

        #region Private Methods

        private static int GetIntClaimValue(string key, HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            var value = identity?.FindFirst(key)?.Value;
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"Claim '{key}' not found or has no value.");
            }
            return int.Parse(value);
        }

        private static string? GetStringClaimValue(string key, HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            return identity?.FindFirst(key)?.Value.ToString();
        }

        private static bool? GetBoolClaimValue(string key, HttpContext context)  // for IsPrimaryOperator
        {
            var user = context.User as ClaimsPrincipal;
            return user?.HasClaim(c => c.Type == key);
        }

        private static Guid GetGuidClaimValue(string key, HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            var value = identity?.FindFirst(key)?.Value;
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"Claim '{key}' not found or has no value.");
            }
            return Guid.Parse(value);
        }

        #endregion Private Methods
    }
}
