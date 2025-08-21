using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mvc.Models;
using System.Security.Claims;

namespace Mvc.Filters
{
    public class CustomAuthorizationAttribute(ICoreService coreService) : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        // Define IUserService and its implementation: This service would encapsulate the logic for interacting with your user store (e.g., database, API) to check user existence and roles.
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                // Not authenticated, redirect to login page (handled by default authentication middleware)
                return;
            }

            #region UserID and Claims Handling

            // user.Identity has the username of the authenticated user in the "name" claim by default
            string? userID = _coreService.GetEmployeeIDByEmployeeName(user.Identity.Name!);

            if (string.IsNullOrEmpty(userID))  // user is not in the ESL.ESL_Employees table but a legitimate user
            {
                // User ID not found, redirect to read-only home page
                //context.Result = new RedirectToActionResult("ReadOnlyHome", "Home", null);
                return;
            }

            // Set Session["UserName"] and Session["UserID"]
            context.HttpContext.Session.SetString("UserName", user.Claims.First(c => c.Type == "name").Value.ToString());
            context.HttpContext.Session.SetString("UserID", userID);

            // Check if the UserID claim exists
            try
            {
                var identity = user.Identity as ClaimsIdentity;

                var existingClaim = user.FindFirst(c => c.Type == AppConstants.UserIDClaimType);

                if (existingClaim != null)
                {
                    // If the UserID claim exists, remove it
                    identity?.RemoveClaim(existingClaim);
                }

                // Add new claim
                identity.AddClaim(new Claim(AppConstants.UserIDClaimType, userID));

                // Sign in again to update claims
                await context.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine($"Error while setting UserID claim: {ex.Message}");
                // Optionally, you can redirect to an error page or handle it accordingly
                context.Result = new RedirectToActionResult("Error", "Home", null);
                return;
            }

            // write to response cookie for the selected plant to be picked up by the ClaimsTransformation
            context.HttpContext.Response.Cookies.Append("UserID", userID);

            //if (!user.HasClaim(c => c.Type == "UserID"))
            //{
            //    // Create a new ClaimsIdentity to add the new claims.
            //    // It's generally recommended to add claims to a new ClaimsIdentity
            //    // and then add that identity to the principal.
            //    ClaimsIdentity claimsIdentity = new();

            //    claimsIdentity.AddClaim(new Claim("userID", userID));

            //    user.AddIdentity(claimsIdentity);
            //}
            //else if (user.FindFirst(c => c.Type == "UserID")?.Value != userID)
            //{
            //    // If the UserID claim exists but does not match the current userID, update it
            //    var existingClaim = user.FindFirst(c => c.Type == "UserID");
            //    if (existingClaim != null)
            //    {
            //        var claimsIdentity = user.Identity as ClaimsIdentity;
            //        claimsIdentity?.RemoveClaim(existingClaim);
            //        claimsIdentity?.AddClaim(new Claim("UserID", userID));
            //    }
            //}
            //else if (user.HasClaim(c => c.Type == "UserID" && c.Value == userID))
            //{
            //    // User exists in claims, proceed with authorization
            //    return;
            //}

            #endregion UserID and Claims Handling

            # region DefaultFacilNoHandling

            // check if the DefaultFacilNo claim exists => indicates the user has selected a facility and has set Session["DefaultFacilNo"] value
            var facilNo = context.HttpContext.Session.GetInt32("DefaultFacilNo");

            if (facilNo is null || facilNo < 0 || facilNo > 13)
            {
                // DefaultFacilNo not found in session, redirect to read-only home page
                context.Result = new RedirectToActionResult("SelectPlant", "Home", null);
                return;
            }

            // User has selected a facility, check and set the DefaultFacilNo claim
            if (!user.HasClaim(c => c.Type == "DefaultFacilNo"))
            {
                // Create a new ClaimsIdentity to add the new claims.
                // It's generally recommended to add claims to a new ClaimsIdentity
                // and then add that identity to the principal.
                ClaimsIdentity claimsIdentity = new();

                claimsIdentity.AddClaim(new Claim("DefaultFacilNo", facilNo.ToString()!));

                user.AddIdentity(claimsIdentity);
            }
            else if (user.FindFirst(c => c.Type == "DefaultFacilNo")?.Value != facilNo.ToString()!)
            {
                // If the UserID claim exists but does not match the current userID, update it
                var existingClaim = user.FindFirst(c => c.Type == "DefaultFacilNo");
                if (existingClaim != null)
                {
                    var claimsIdentity = user.Identity as ClaimsIdentity;
                    claimsIdentity?.RemoveClaim(existingClaim);
                    claimsIdentity?.AddClaim(new Claim("DefaultFacilNo", facilNo.ToString()!));
                }
            }
            else if (user.HasClaim(c => c.Type == "DefaultFacilNo" && c.Value == facilNo.ToString()!))
            {
                // User exists in claims, proceed with authorization
                return;
            }

            #endregion DefaultFacilNo Claim Handling

            #region UserRole Claim Handling

            string? userRole = await _coreService.GetRole(userID, facilNo);

            if (string.IsNullOrEmpty(userRole)) // not an operator (not in the ESL.ESL_UserRoles table)
            {
                // do not set claim for role, shiftNo, or operatorType
                context.Result = new RedirectToActionResult("Index", "Home", new { area = "Public" });
                return;
            }

            // User has a role registered in UserRoles, check and set the Role claim
            if (!user.HasClaim(c => c.Type == "Role"))
            {
                // Create a new ClaimsIdentity to add the new claims.
                // It's generally recommended to add claims to a new ClaimsIdentity
                // and then add that identity to the principal.
                ClaimsIdentity claimsIdentity = new();

                claimsIdentity.AddClaim(new Claim("Role", userRole));

                user.AddIdentity(claimsIdentity);
            }
            else if (user.FindFirst(c => c.Type == "Role")?.Value != userRole)
            {
                // If the UserID claim exists but does not match the current userID, update it
                var existingClaim = user.FindFirst(c => c.Type == "Role");
                if (existingClaim != null)
                {
                    var claimsIdentity = user.Identity as ClaimsIdentity;
                    claimsIdentity?.RemoveClaim(existingClaim);
                    claimsIdentity?.AddClaim(new Claim("Role", userRole));
                }
            }
            else if (user.HasClaim(c => c.Type == "Role" && c.Value == userRole))
            {
                // User exists in claims, proceed with authorization
                return;
            }

            #endregion DefaultFacilNo and Role Handling

            return;
        }
    }
}
