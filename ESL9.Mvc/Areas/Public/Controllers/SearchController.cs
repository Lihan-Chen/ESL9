using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Public.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
