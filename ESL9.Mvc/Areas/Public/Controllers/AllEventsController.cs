using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Public.Controllers
{
    public class AllEventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
