using Microsoft.AspNetCore.Mvc;

namespace Prototype.Areas.Public.Controllers
{
    [Area("Public")]
    public class AllEventsViewerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
