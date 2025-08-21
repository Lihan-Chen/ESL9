using Microsoft.AspNetCore.Authentication;
using Prototype.Models;
using System.Security.Claims;

namespace Prototype
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            string userIDClaimType = "userid";
            string defaultFacilNoClaimType = "defaultfacilno";
            string roleClaimType = "role";

            SessionUserDto sessionUser = new("Chen,Lihan", "U06337", 1, "ESL_ADMIN", 1, true);

            List<Claim> claims =
            [
                new(userIDClaimType, sessionUser.UserID ?? String.Empty), // Example user ID, you can change it as needed
                new(defaultFacilNoClaimType, sessionUser.FacilNoOnDuty.ToString()), // Example default facility number, you can change it as needed
                new(roleClaimType, sessionUser.UserRole ?? String.Empty) // Example role, you can change it as needed
            ];
            
            foreach (var claim in claims)
            {
                // 1. Check if the claim already exists to avoid re-adding it on subsequent calls.
                // IClaimsTransformation can be called multiple times during a request lifecycle.
                if (!principal.HasClaim(c => c.Type == claim.Type))
                {
                    // Create a new ClaimsIdentity to add the new claims.
                    // It's generally recommended to add claims to a new ClaimsIdentity
                    // and then add that identity to the principal.
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(); //= new(principal.Identity.Claims, principal.Identity.AuthenticationType, principal.Identity.Name, principal.Identity.Role););

                    claimsIdentity.AddClaim(new Claim(claim.Type, claim.Value));

                    principal.AddIdentity(claimsIdentity);
                }
              
                if (principal.HasClaim(c => c.Type == claim.Type && c.Value == claim.Value))
                {
                    continue; // Skip adding if the claim already exists with the same value
                }
                else //
                {
                    var existingClaim = principal.FindFirst(claim.Type);

                    if (existingClaim != null && existingClaim.Value! != claim.Value)
                    {
                        // Create a new ClaimsIdentity for the updated claim.
                        var updatedClaimsIdentity = new ClaimsIdentity();
                        updatedClaimsIdentity.AddClaim(new Claim(claim.Type, claim.Value));

                        // Remove the old identity (or specific claims) and add the new one.
                        // This is a simplified approach; more robust handling might involve
                        // finding and replacing specific claims within an existing identity.
                        var originalIdentity = principal.Identity as ClaimsIdentity;
                        if (originalIdentity != null && originalIdentity.HasClaim(c => c.Type == claim.Type))
                        {
                            // Remove the existing claim and add the updated one
                            originalIdentity.RemoveClaim(existingClaim);
                            originalIdentity.AddClaim(new Claim(claim.Type, claim.Value));
                        }                        
                    }
                }
            }
            return Task.FromResult(principal);
        }
    }
}
