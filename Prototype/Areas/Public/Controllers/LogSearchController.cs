using Microsoft.AspNetCore.Mvc;

namespace Prototype.Areas.Public.Controllers
{
    [Area("Public")]
    public class LogSearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
