using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Public.Controllers
{
    public class _BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
