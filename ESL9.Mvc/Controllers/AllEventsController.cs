using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    [Authorize]
    public class AllEventsController : Controller
    {
        //private readonly IFacilityRepository _facilityRepository;
        //private readonly ILogTypeRepository _logTypeRepository;

        //public HomeController(
        //    IFacilityRepository facilityRepository,
        //    ILogTypeRepository logTypeRepository)
        //{
        //    _facilityRepository = facilityRepository;
        //    _logTypeRepository = logTypeRepository;
        //}

        public IActionResult Index()
        {
            var _facilities = new List<(int, string)> { (1, "OCC"), (2, "Diemer") }; //HttpContext.RequestServices.GetService<Application.Interfaces.IRepositories.IFacilityRepository>();

            var _logTypes = new List<string> { "Clearance", "EOS", "FlowChange" }; //HttpContext.RequestServices.GetService<Application.Interfaces.IRepositories.ILogTypeRepository>();

            ViewBag.Facilities = _facilities;
            ViewBag.LogTypes = _logTypes;

            return View();
        }

        //[HttpGet]
        //[Route("AllEvent")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
