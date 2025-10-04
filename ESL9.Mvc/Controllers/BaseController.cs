using Application.Interfaces.IServices;
using Core.Models.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Models;
using Mvc.Models.Enum;
using System.Linq;
using System.Security.Claims;
using LogType = Mvc.Models.Enum.LogType;

namespace Mvc.Controllers 
{
    public class BaseController<T>(ICoreService coreService, ILogger<T> logger) : Controller where T : BaseController<T>
    {
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        ILogger<T> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        #region Basic DateTime

        protected static DateTime ShiftStartTime = DateTime.Today.Add(TimeSpan.Parse(AppConstants.DayShiftStartText));
        protected static DateTime ShiftEndTime = DateTime.Today.Add(TimeSpan.Parse(AppConstants.DayShiftEndText));
        protected static DateTime Now = DateTime.Now;
        protected static DateOnly Today = DateOnly.FromDateTime(DateTime.Now);
        protected static DateOnly Tomorrow = Today.AddDays(+1);

        // ToDo: check if this format is correct
        protected string YesterdayDate = Today.AddDays(-1).ToString("MM/dd/yyyy");
        protected string TodayDate = Today.ToString("yyyyMMdd");
        protected string TomorrowDate = Tomorrow.ToString("yyyyMMdd");
        
        protected static int DaysOffSet = -2;

        // TimeSpan for two and half hours
        protected static TimeSpan TimeSpan = new(2, 30, 0);

        protected bool OkToProceed = false;

        protected static int _pageSize = 40;

        #endregion

        #region Public Properties for User Session

        public bool IsAuthenticated => HttpContext.User.Identity?.IsAuthenticated ?? false;

        public string? UserName => IsAuthenticated ? User.FindFirst(c => c.Type == AppConstants.NameClaimType)?.Value! : string.Empty;

        // The first thing for the user to do is to get authenticated and have a UserID claim
        // If UserID claim is not present, it indicates a new session
        public bool IsNewSession => !User.HasClaim(c => c.Type == AppConstants.UserIDClaimType);

        public string? UserID => User.HasClaim(c => c.Type == AppConstants.UserIDClaimType)
            ? GetClaimValue(User, AppConstants.UserIDClaimType) ?? string.Empty :
              _coreService.GetEmployeeIDByEmployeeName(UserName!) ?? string.Empty;

        // User is checked in and ready to go only if DefaultFacilNo claim is present, Public user does not have this claim
        public bool IsUserCheckedIn => !User.HasClaim(c => c.Type == AppConstants.DefaultFacilNoClaimType);


        // Update DefaultFacilNo property to parse the claim value to int? instead of returning string
        public int? DefaultFacilNo =>
            User.HasClaim(c => c.Type == AppConstants.DefaultFacilNoClaimType)
                ? int.TryParse(GetClaimValue(User, AppConstants.DefaultFacilNoClaimType), out var result) ? result : (int?)null
                : null;

        public int? DefaultLogTypeNo;

        // Role is valid only if associated with a FacilNo (ValueObject)
        //public string? Role => User.HasClaim(c => c.Type == AppConstants.RoleClaimType) ? GetClaimValue(User, AppConstants.RoleClaimType) : null; // User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        //public int? ShiftNo => User.HasClaim(c => c.Type == AppConstants.ShiftNoClaimType) ? int.Parse(GetClaimValue(User, AppConstants.ShiftNoClaimType)!) : null;

        //public bool? IsPrimaryOperator => User.HasClaim(c => c.Type == AppConstants.IsPrimaryOperatorClaimType) && GetClaimValue(User, AppConstants.IsPrimaryOperatorClaimType) == "true";

        #endregion Public Properties for User Session

        public int? FacilNo
        {
            get
            {
                // From current parameter
                if (UserAssignedFacilNo is not null)
                {
                    return UserAssignedFacilNo;
                }

                // From sessionkey AssignedFacilNo
                //if (HttpContext.Session.TryGetValue(AppConstants.AssignedFacilNoSessionKey, out var value) && value.Length > 0)
                //{
                //    return BitConverter.ToInt32(value, 0);
                //}

                // From claims (mainly used for initail default facilNo)
                return DefaultFacilNo;
            }

            set
            {
                if (value is not null)
                {
                    UserAssignedFacilNo = value;
                    HttpContext.Session.SetInt32(AppConstants.AssignedFacilNoSessionKey, value.Value);
                }
            }
        }

        public static IEnumerable<object> EslOpTypeList = Enum.GetValues(typeof(OperatorType))
                .Cast<OperatorType>()
                .Select(s => new { ID = s, Name = s.ToString() });
                //.Prepend(new { ID = "", Name = "Assigned As" });


        public static IEnumerable<object> EslShiftList = Enum.GetValues(typeof(Shift))
                .Cast<Shift>()
                .Select(s => new { ID = s, Name = s.ToString() });

        public bool IsUserAnOperator => FacilNo != null && !string.IsNullOrEmpty(UserID) && _coreService.IsInRole(UserID, "ESL_OPERATOR", FacilNo).Result;

        public bool ShowAlert => HttpContext.Session.TryGetValue("ShowAlert", out var value) && value.Length > 0 && BitConverter.ToBoolean(value, 0);
        // Remove the problematic field initializer for userRole
        // Instead, implement userRole as a property that accesses _coreService and UserID at runtime

        internal string UserRole
        {
            get
            {
                // If UserID is null, return "Viewer"
                if (string.IsNullOrEmpty(UserID))
                    return "Public";

                // GetRole returns a Task<string?>, so we need to await or use .Result
                var roleTask = _coreService.HasAnyRoles(UserID); //GetRole(UserID, null);
                bool? role = roleTask?.Result;
                return IsUserAnOperator ? "Internal" : "Public"; // role.HasValue && role.Value
            }
        }

        // This is a temporary storage for the selected FacilNo during the current request
        public int? UserAssignedFacilNo;  // => GetSessionValue<int>(AppConstants.AssignedFacilNoSessionKey);

        public Shift DefaultShift =>  Now >= ShiftStartTime && Now < ShiftEndTime ? Shift.Day : Shift.Night;

        public DateOnly DefaultStartDate => Today.AddDays(DaysOffSet); // 2 days ago
        public DateOnly DefaultEndDate => Tomorrow; // Today.AddDays(1);

        // HttpContext.Session.TryGetValue("FacilNo", out var value) && value.Length > 0 ? BitConverter.ToInt32(value, 0) : null;

        // Check into the logic since FacilNo is set first, and may not be sufficient to indicate that user is checked in
        // Depending on role and value of ClaimTypes.Role, the user may not be checked in
        //internal bool IsUserCheckedIn(ClaimsPrincipal user)
        //{
        //    bool isFacilNoSet = user.HasClaim(c => c.Type == AppConstants.DefaultFacilNoClaimType);

        //    //FacilNo = user.HasClaim(c => c.Type == "facilNo") ? int.Parse(GetClaimValue(user, "facilNo")!) : null;

        //    bool isViewOnly =  isFacilNoSet && user.HasClaim(c => c.Type == AppConstants.RoleClaimType && c.Value == "Viewer");

        //    bool isOperator = isFacilNoSet && 
        //                       user.HasClaim(c => c.Type == "role" && c.Value != "Viewer") && 
        //                       user.HasClaim(c => c.Type == "ShiftNo") &&
        //                       user.HasClaim(c => c.Type == "OperatorType");



        //    // determine the role of the user based on claims or session
        //    if (FacilNo is not null)  // user has selected a facility
        //    {
        //        if (isViewOnly || isOperator) return true; // User has selected a facility and is checked in
        //    }

        //    return false;

        //return user.Identity?.IsAuthenticated == true &&
        //           user.HasClaim(c => c.Type == "FacilNo") &&
        //           user.HasClaim(c => c.Type == "ShiftNo") &&
        //           user.HasClaim(c => c.Type == "OperatorType");
        //}

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

        internal Task<ClaimsPrincipal>? SetClaim(ClaimsPrincipal user, string? claimType, string? claimValue, bool rememberMe)
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

            // Set authentication properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe, // <-- This enables "Remember Me"
                ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddDays(14) : DateTimeOffset.UtcNow.AddHours(1)
            };

            // Sign in again to update claims and persist the changes
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties
            ).Wait(); // Wait for the sign-in to complete

            return Task.FromResult(new ClaimsPrincipal(identity));
        }

        // Fix the method signature to use IEnumerable<KeyValuePair<string, string>> instead of IEnumerable<string, string>
        internal Task<ClaimsPrincipal> SetClaim(ClaimsPrincipal user, IEnumerable<KeyValuePair<string, string>> claims, bool rememberMe)
        {
            var identity = (ClaimsIdentity)user.Identity!;
            
            foreach (var c in claims)
            {
                if (string.IsNullOrEmpty(c.Key) || string.IsNullOrEmpty(c.Value))
                {
                    // Skip empty claims
                    continue;
                }

                var oldClaim = identity.FindFirst(c.Key);
                if (oldClaim != null)
                {
                    identity.RemoveClaim(oldClaim);
                }

                Claim claim = new Claim(c.Key, c.Value);
                identity.AddClaim(claim);
            }

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

        // Replace the problematic method definition with a non-generic overload for int
        internal void SetSessionValue(string key, int value)
        {
            HttpContext.Session.SetInt32(key, value);
        }

        internal void SetSessionValue(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
        }

        internal T? GetSessionValue<T>(string key) where T : class
        {
            if (HttpContext.Session.TryGetValue(key, out var value))
            {
                return value as T;
            }
            return null;
        }

        // SelectList
        // Fix for CS0693: Rename the type parameter in GetSelectList<T> to avoid conflict with BaseController<T>
        internal SelectList GetSelectList<U>(IEnumerable<U> items, string valueField, string textField, object? selectedValue = null)
        {
            return new SelectList(items, valueField, textField, selectedValue);
        }

        public SelectList FacilOptions => new SelectList(
                    Enum.GetValues(typeof(Facil))
                        .Cast<Facil>()
                        .Select(f => new FacilSelectViewModel
                        {
                            FacilNo = (int)f,
                            FacilName = FacilExtensions.GetFacilName(f),
                            IsSelected = f == (Facil)DefaultFacilNo
                        })
                        .ToList(),
                    nameof(FacilSelectViewModel.FacilNo),
                    nameof(FacilSelectViewModel.FacilName),
                    DefaultFacilNo
                );

        public SelectList LogTypeOptions => new SelectList(
                    Enum.GetValues(typeof(LogType))
                        .Cast<LogType>()
                        .Select(s => new LogTypeSelectViewModel
                        {
                            LogTypeNo = (int)s,
                            LogTypeName = s.ToString(),
                            IsSelected = s == (LogType)DefaultLogTypeNo
                        })
                        .ToList(),
                    nameof(LogTypeSelectViewModel.LogTypeNo),
                    nameof(LogTypeSelectViewModel.LogTypeName),
                    DefaultLogTypeNo
                );

        //public SelectList ShiftOptions => new SelectList(
        //            Enum.GetValues(typeof(Shift))
        //                .Cast<Shift>()
        //                .Select(s => new ShiftSelectViewModel
        //                {
        //                    ShiftNo = (int)s,
        //                    ShiftName = s.ToString(),
        //                    IsSelected = s == DefaultShift
        //                })
        //                .ToList(),
        //            nameof(ShiftSelectViewModel.ShiftNo),
        //            nameof(ShiftSelectViewModel.ShiftName),
        //            DefaultShift
        //        );

        #endregion Helpers
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
