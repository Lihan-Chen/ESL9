using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Mvc.Controllers;

namespace Mvc.Areas.Public.Controllers
{
    public class HomeController(ICoreService coreService,
                            ILogger<HomeController> logger) : _BaseController<HomeController>(coreService, logger)
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
