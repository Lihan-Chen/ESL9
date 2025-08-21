using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
