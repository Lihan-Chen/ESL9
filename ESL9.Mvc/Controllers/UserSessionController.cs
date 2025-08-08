using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mvc.Controllers
{
    public class UserSessionController : Controller
    {
        public IActionResult Index()
        {
            ISession session = HttpContext.Session;

            ClaimsPrincipal user = HttpContext.User;

            //foreach (Claim claim in user.Claims)
            //{
            //    _logger.LogInformation("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
            //}

            //session.TryGetValue("UserSession", out userSession);

            return View();
        }
    }
}
