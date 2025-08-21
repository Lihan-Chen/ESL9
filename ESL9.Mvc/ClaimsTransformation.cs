using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Mvc.Models;
using System.Collections;
using System.Security.Claims;

namespace Mvc
{
    public class ClaimsTransformation(ICoreService coreService) : IClaimsTransformation
    {
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {           
            try
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity();

                if (!principal.HasClaim(c => c.Type == AppConstants.UserIDClaimType))
                {

                    string? userName = principal.FindFirst(c => c.Type == AppConstants.NameClaimType)?.Value;

                    string? userID = _coreService.GetEmployeeByEmployeeName(userName).Result?.EmployeeID;  //"U06337"; 

                //int? facilNo = int.Parse(principal.FindFirst(c => c.Type == AppConstants.DefaultFacilNoClaimType)?.Value); // _coreService.GetEmployeeFacilNobyEmployeeName(userName!).Result; // 1; // Default to 1 if null

                    if (userID == null)
                    {
                        throw new InvalidOperationException("User ID cannot be null. Every authenticated user must have been assigned an User ID (UID).");
                    }
                              
                    claimsIdentity.AddClaim(new Claim(AppConstants.UserIDClaimType, userID));
                }
                
                principal.AddIdentity(claimsIdentity);
 
                return Task.FromResult(principal);

                //var oldClaim = principal.FindFirst(c => c.Type == AppConstants.UserIDClaimType);

                //if (oldClaim != null)
                //{
                //    // If the UserID claim exists, remove it
                //    claimsIdentity.RemoveClaim(oldClaim);
                //}
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine($"Error while setting UserID claim: {ex.Message}");
                // Optionally, you can redirect to an error page or handle it accordingly
                throw new InvalidOperationException("Error while setting UserID claim.", ex);
            }
          
        }
    }
}

//if (!principal.HasClaim(c => c.Type == AppConstants.DefaultFacilNoClaimType && c.Value == facilNo!.ToString()))
//{
//    if (facilNo != null && 0 < facilNo && facilNo < 14 && !principal.HasClaim(c => c.Type == AppConstants.DefaultFacilNoClaimType && c.Value == facilNo.ToString()))
//    {
//        claimsIdentity.AddClaim(new Claim(AppConstants.DefaultFacilNoClaimType, facilNo.ToString()));
//    }

//}

//var roleClaimValue = _coreService.GetRole(userID, facilNo).Result ?? string.Empty; // role is dependent on userID and facilNo (role only exists for a facility)

//if (!string.IsNullOrEmpty(roleClaimValue) && !principal.HasClaim(c => c.Type == AppConstants.RoleClaimType && c.Value == roleClaimValue))
//{
//    claimsIdentity.AddClaim(new Claim(AppConstants.RoleClaimType, roleClaimValue));
//}

//bool isPrimaryOperator = false; ;  // get from database first

//var isPrimaryOperatorClaim = new Claim(AppConstants.IsPrimaryOperatorClaimType, isPrimaryOperator.ToString(), ClaimValueTypes.Boolean);

//if (roleClaimValue is not null && !principal.HasClaim(c => c.Type == AppConstants.IsPrimaryOperatorClaimType))  // only add if role exists for a facility
//{
//    claimsIdentity.AddClaim(isPrimaryOperatorClaim);
//}

//int? shiftNo = (now > now.Date.AddHours(6) && now < now.Date.AddHours(18)) ? 1 : 2;  // get from database first

////if (session != null && session.TryGetValue("ShiftNo", out byte[]? shiftNoBytes))
////{
////    shift = BitConverter.ToInt32(shiftNoBytes, 0); // Default to ESL_ADMIN if nul
////}

//if (roleClaimValue is not null && shiftNo is not null && !principal.HasClaim(c => c.Type == AppConstants.ShiftNoClaimType && c.Value == shiftNo.ToString()))
//{
//    claimsIdentity.AddClaim(new Claim(AppConstants.ShiftNoClaimType, shiftNo.ToString()));
//}
