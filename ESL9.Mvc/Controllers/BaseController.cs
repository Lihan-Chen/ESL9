using Application.Dtos;
using Application.Interfaces.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Enum;
using System.Data;
using System.Security.Claims;

namespace Mvc.Controllers 
{
    public class BaseController<T>(ICoreService coreService, ILogger<T> logger) : Controller where T : BaseController<T>
    {
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        public bool IsAuthenticated => HttpContext.User.Identity?.IsAuthenticated ?? false;

        public string? UserName => User.FindFirst(c => c.Type == "name")?.Value!;

        public string? UserID => !string.IsNullOrEmpty(UserName) ? _coreService.GetEmployeeIDByEmployeeName(UserName) : null;

        public bool IsUserAnOperator => !string.IsNullOrEmpty(UserID) && _coreService.IsInRole(UserID, "ESL_OPERATOR", FacilNo).Result;

        public bool ShowAlert => HttpContext.Session.TryGetValue("ShowAlert", out var value) && value.Length > 0 && BitConverter.ToBoolean(value, 0);

        public int? FacilNo; // HttpContext.Session.TryGetValue("FacilNo", out var value) && value.Length > 0 ? BitConverter.ToInt32(value, 0) : null;

        // Check into the logic since FacilNo is set first, and may not be sufficient to indicate that user is checked in
        // Depending on role and value of ClaimTypes.Role, the user may not be checked in
        public bool IsUserCheckedIn(ClaimsPrincipal user)
        {
            bool viewOnly = user.HasClaim(c => c.Type == "role" && c.Value == "Viewer");

            bool isCheckedIn = !viewOnly && 
                               user.HasClaim(c => c.Type == "ShiftNo") &&
                               user.HasClaim(c => c.Type == "OperatorType");

            FacilNo = user.HasClaim(c => c.Type == "facilNo") ? int.Parse(GetClaimValue(user, "facilNo")!) : null;

            // determine the role of the user based on claims or session
            if (FacilNo is not null)  // user has selected a facility
            {
                if (isCheckedIn || viewOnly) return true; // User has selected a facility and is checked in
            }
            
            return false;

            //return user.Identity?.IsAuthenticated == true &&
            //           user.HasClaim(c => c.Type == "FacilNo") &&
            //           user.HasClaim(c => c.Type == "ShiftNo") &&
            //           user.HasClaim(c => c.Type == "OperatorType");
        }

        public string? GetClaimValue(ClaimsPrincipal principal, string claimType)
        {
            var claim = principal.FindFirst(claimType);
            return claim?.Value; // Returns the claim value or null if not found
        }

        //public UserSessionDto GetUserSession()
        //{
        //    if (HttpContext.Session.TryGetValue("SessionID", out var value) && value.Length > 0)
        //    {
        //       // var sessionId = BitConverter.ToString(value).Replace("-", string.Empty);

        //        return System.Text.Json.JsonSerializer.Deserialize<UserSession>(value)!;
        //    }

        //    // If session data is not available, return a new UserSessionDto
        //    // or handle the case as needed (e.g., redirect to login)
        //    logger.LogWarning("Session data not found, returning new UserSessionDto.");

        //    return new UserSessionDto();
        //}

        //public string? FacilName => HttpContext.Session.TryGetValue("FacilName", out var value) && value.Length > 0 ?
        //                        System.Text.Encoding.UTF8.GetString(value) : string.Empty;

        //public static string GetSessionValue(string key)
        //{
        //    if (HttpContext.Session != null && HttpContext.Session != null && HttpContext.Session[key] != null)
        //    {
        //        return HttpContext.Session[key].ToString();
        //    }
        //    return null;
        //}
    }

}
