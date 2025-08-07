using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class UserSessionController1 : Controller
    {
        public IActionResult Index()
        {
            //var userSession = HttpContext.Session.Get<UserSessionDto>("UserSession");

            return View();
        }
    }
}
