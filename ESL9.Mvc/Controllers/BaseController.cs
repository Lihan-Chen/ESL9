using ESL9.Mvc.Domain.BusinessEntities;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class BaseController : Controller
    {
        public bool IsAuthenticated => HttpContext.User.Identity?.IsAuthenticated ?? false;

        public string? UserName => HttpContext.User.Identity?.Name;

        public static string? UserID = ""; // => HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value;

        public static bool IsUserAnOperator = !string.IsNullOrEmpty(UserID); 

        public bool ShowAlert => HttpContext.Session.TryGetValue("ShowAlert", out var value) && value.Length > 0 && BitConverter.ToBoolean(value, 0);

        public int? FacilNo; // => HttpContext.Session.TryGetValue("FacilNo", out var value) && value.Length > 0 ? 
                               //BitConverter.ToInt32(value, 0) : null;

        //public string? FacilName => HttpContext.Session.TryGetValue("FacilName", out var value) && value.Length > 0 ?
        //                        System.Text.Encoding.UTF8.GetString(value) : string.Empty;

    }
}
