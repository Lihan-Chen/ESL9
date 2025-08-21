using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using System.Security.Claims;

namespace Mvc.Controllers 
{
    public class BaseController<T>(ICoreService coreService, ILogger<T> logger) : Controller where T : BaseController<T>
    {
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        ILogger<T> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        #region Public Properties for User Session

        public bool IsAuthenticated => HttpContext.User.Identity?.IsAuthenticated ?? false;

        public string? UserName => IsAuthenticated ? User.FindFirst(c => c.Type == AppConstants.NameClaimType)?.Value! : string.Empty;

        public string? UserID => User.HasClaim(c => c.Type == AppConstants.UserIDClaimType)
            ? GetClaimValue(User, AppConstants.UserIDClaimType) ?? _coreService.GetEmployeeIDByEmployeeName(UserName!) ?? string.Empty
            : string.Empty;

            //!string.IsNullOrEmpty(UserName) ? _coreService.GetEmployeeIDByEmployeeName(UserName) : null;

        // Update DefaultFacilNo property to parse the claim value to int? instead of returning string

        public int? DefaultFacilNo =>
            User.HasClaim(c => c.Type == AppConstants.DefaultFacilNoClaimType)
                ? int.TryParse(GetClaimValue(User, AppConstants.DefaultFacilNoClaimType), out var result) ? result : (int?)null
                : null;

        // Role is valid only if associated with a FacilNo (ValueObject)
        public string? Role => User.HasClaim(c => c.Type == AppConstants.RoleClaimType) ? GetClaimValue(User, AppConstants.RoleClaimType) : null; // User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        public int? ShiftNo => User.HasClaim(c => c.Type == AppConstants.ShiftNoClaimType) ? int.Parse(GetClaimValue(User, AppConstants.ShiftNoClaimType)!) : null;

        public bool? IsPrimaryOperator => User.HasClaim(c => c.Type == AppConstants.IsPrimaryOperatorClaimType) && GetClaimValue(User, AppConstants.IsPrimaryOperatorClaimType) == "true";

        #endregion Public Properties for User Session

        public int? FacilNo
        {
            get
            {
                // From current parameter
                if (UserSelectedFacilNo is not null)
                {
                    return UserSelectedFacilNo;
                }

                // From session
                if (HttpContext.Session.TryGetValue(AppConstants.SelectedFacilNoSessionKey, out var value) && value.Length > 0)
                {
                    return BitConverter.ToInt32(value, 0);
                }

                // From claims (mainly used for initail default facilNo)
                return DefaultFacilNo;
            }

            set
            {
                if (value is not null)
                {
                    UserSelectedFacilNo = value;
                    HttpContext.Session.SetInt32(AppConstants.SelectedFacilNoSessionKey, value.Value);
                }
            }
        }

        public bool IsUserAnOperator => !string.IsNullOrEmpty(UserID) && _coreService.IsInRole(UserID, "ESL_OPERATOR", FacilNo).Result;

        public bool ShowAlert => HttpContext.Session.TryGetValue("ShowAlert", out var value) && value.Length > 0 && BitConverter.ToBoolean(value, 0);
        // Remove the problematic field initializer for userRole
        // Instead, implement userRole as a property that accesses _coreService and UserID at runtime

        public string UserRole
        {
            get
            {
                // If UserID is null, return "Viewer"
                if (string.IsNullOrEmpty(UserID))
                    return "Viewer";

                // GetRole returns a Task<string?>, so we need to await or use .Result
                var roleTask = _coreService.GetRole(UserID, null);
                var role = roleTask?.Result;
                return role ?? "Viewer";
            }
        }

        public int? UserSelectedFacilNo; // HttpContext.Session.TryGetValue("FacilNo", out var value) && value.Length > 0 ? BitConverter.ToInt32(value, 0) : null;

        // Check into the logic since FacilNo is set first, and may not be sufficient to indicate that user is checked in
        // Depending on role and value of ClaimTypes.Role, the user may not be checked in
        internal bool IsUserCheckedIn(ClaimsPrincipal user)
        {
            bool isFacilNoSet = user.HasClaim(c => c.Type == AppConstants.DefaultFacilNoClaimType);

            //FacilNo = user.HasClaim(c => c.Type == "facilNo") ? int.Parse(GetClaimValue(user, "facilNo")!) : null;

            bool isViewOnly =  isFacilNoSet && user.HasClaim(c => c.Type == AppConstants.RoleClaimType && c.Value == "Viewer");

            bool isOperator = isFacilNoSet && 
                               user.HasClaim(c => c.Type == "role" && c.Value != "Viewer") && 
                               user.HasClaim(c => c.Type == "ShiftNo") &&
                               user.HasClaim(c => c.Type == "OperatorType");

            

            // determine the role of the user based on claims or session
            if (FacilNo is not null)  // user has selected a facility
            {
                if (isViewOnly || isOperator) return true; // User has selected a facility and is checked in
            }
            
            return false;

            //return user.Identity?.IsAuthenticated == true &&
            //           user.HasClaim(c => c.Type == "FacilNo") &&
            //           user.HasClaim(c => c.Type == "ShiftNo") &&
            //           user.HasClaim(c => c.Type == "OperatorType");
        }

        //public string? GetClaimValue(ClaimsPrincipal principal, string claimType)
        //{
        //    var claim = principal.FindFirst(claimType);
        //    return claim?.Value; // Returns the claim value or null if not found
        //}

        #region Helpers

        internal static string? GetClaimValue(ClaimsPrincipal user, string claimType)
        {
            return user.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
        }

        internal static string? GetClaimValue(ClaimsPrincipal user, Func<Claim, bool> predicate)
        {
            return user.Claims.FirstOrDefault(predicate)?.Value;
        }

        internal static Claim? GetClaim(ClaimsPrincipal user, string claimType)
        {
            return user.Claims.FirstOrDefault(c => c.Type == claimType);
        }

        internal Task<ClaimsPrincipal>? SetClaim(ClaimsPrincipal user, string? claimType, string? claimValue)
        {
            if (string.IsNullOrEmpty(claimType) || string.IsNullOrEmpty(claimValue))
            {
                return null;
            }

            var identity = (ClaimsIdentity)user.Identity!;

            // Remove old claim if it exists
            var oldClaim = identity.FindFirst(claimType);
            if (oldClaim != null)
            {
                identity.RemoveClaim(oldClaim);
            }

            // Add new claim
            var newClaim = new Claim(claimType, claimValue);
            identity.AddClaim(newClaim);

            // Sign in again to update claims
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity)
            ).Wait(); // Wait for the sign-in to complete

            return Task.FromResult(new ClaimsPrincipal(identity));
        }

        // Fix the method signature to use IEnumerable<KeyValuePair<string, string>> instead of IEnumerable<string, string>
        internal Task<ClaimsPrincipal> SetClaim(ClaimsPrincipal user, IEnumerable<KeyValuePair<string, string>> claims, bool rememberMe)
        {
            foreach (var c in claims)
            {
                if (string.IsNullOrEmpty(c.Key) || string.IsNullOrEmpty(c.Value))
                {
                    continue; // Skip empty claims
                }

                Claim claim = new Claim(c.Key, c.Value);
                user = SetClaim(user, c.Key, c.Value).Result;
            }

            var identity = (ClaimsIdentity)user.Identity!;

            // Set authentication properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddDays(14) : DateTimeOffset.UtcNow.AddHours(1)
            };

            // Sign in again to update claims
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties
            ).Wait();

            return Task.FromResult(new ClaimsPrincipal(identity));
        }

        internal Task<ClaimsPrincipal>? SetClaim(ClaimsPrincipal user, Func<Claim, bool> predicate, string? claimValue, bool? rememberMe = false)
        {
            if (string.IsNullOrEmpty(claimValue))
            {
                return null;
            }
            var identity = (ClaimsIdentity)user.Identity!;
            // Remove old claim if it exists
            var oldClaim = identity.Claims.FirstOrDefault(predicate);
            if (oldClaim != null)
            {
                identity.RemoveClaim(oldClaim);
            }
            // Add new claim
            var newClaim = new Claim(predicate.Method.Name, claimValue);
            identity.AddClaim(newClaim);

            // Set authentication properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe ?? false, // <-- This enables "Remember Me"
                ExpiresUtc = rememberMe == true ? DateTimeOffset.UtcNow.AddDays(14) : DateTimeOffset.UtcNow.AddHours(1)
            };

            // Sign in again to update claims
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties
            ).Wait(); // Wait for the sign-in to complete

            // Return the Principal with updated claims
            return Task.FromResult(new ClaimsPrincipal(identity));
        }

        internal void SetSessionValue(string key, object value)
        {
            if (value is null)
            {
                HttpContext.Session.Remove(key);
            }
            else
            {
                HttpContext.Session.SetString(key, value.ToString()!);
            }
        }

        internal T? GetSessionValue<T>(string key) where T : class
        {
            if (HttpContext.Session.TryGetValue(key, out var value))
            {
                return value as T;
            }
            return null;
        }

        #endregion
        //public Task<ClaimsPrincipal> SetClaim(string ClaimType, ClaimsTransformation claimTransform)
        //{
        //    switch (ClaimType)
        //    {
        //        case AppConstants.NameClaimType:
        //            return Task.FromResult<string?>(claimTransform.GetNameClaimValue());

        //        case AppConstants.UserIDClaimType:
        //            return Task.FromResult<string?>(claimTransform.GetUserIDClaimValue());

        //        case AppConstants.DefaultFacilNoClaimType:
        //            return Task.FromResult<string?>(claimTransform.GetDefaultFacilNoClaimValue());

        //        case AppConstants.RoleClaimType:
        //            return Task.FromResult<string?>(claimTransform.GetRoleClaimValue());

        //        case AppConstants.ShiftNoClaimType:
        //            return Task.FromResult<string?>(claimTransform.GetShiftNoClaimValue());

        //        case AppConstants.OperatorTypeClaimType:
        //            return Task.FromResult<string?>(claimTransform.GetOperatorTypeClaimValue());

        //        default:
        //            _logger.LogWarning($"Unknown claim type: {ClaimType}");
        //            return Task.FromResult<string?>(null);
        //    }
        //}

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
