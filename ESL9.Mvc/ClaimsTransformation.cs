using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Mvc
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Add a new claim if it doesn't already exist
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            string userID = "U06337"; // Example user ID, you can change it as needed

            var claimType = "userID";
            var claimValue = userID; // Example value, you can change it as needed

            if (!principal.HasClaim(claim => claim.Type == claimType))
            {
                claimsIdentity.AddClaim(new Claim(claimType, userID));
            }
            
            principal.AddIdentity(claimsIdentity);

            return Task.FromResult(principal);
        }
    }
}
