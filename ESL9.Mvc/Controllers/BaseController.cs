using Application.Interfaces.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
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

        public bool IsUserCheckedIn(ClaimsPrincipal user)
        {
            return user.Identity?.IsAuthenticated == true &&
                   user.HasClaim(c => c.Type == "FacilNo") &&
                   user.HasClaim(c => c.Type == "ShiftNo") &&
                   user.HasClaim(c => c.Type == "OperatorType");
        }
        
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
