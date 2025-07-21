using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
    [Authorize]
    public class AllEventController(IAllEventService allEventService, ICoreService coreService, ILogger<AllEventController> logger) : BaseController<AllEventController>(coreService, logger)
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ILogger<AllEventController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public IActionResult Index([FromBody] _LogFilterPartialViewModel? logFilterPartial) //, int? facilNo, DateTime? startDate, DateTime? endDate, string searchString, int? page, bool? operatorType) // , string active, string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (logFilterPartial is null)
            {
                logFilterPartial = new _LogFilterPartialViewModel
                {
                    SelectedFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo"),
                    //SelectedLogTypeNo = _httpContext.Session.GetInt32("SelectedLogTypeNo");
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(1)
                };
                //logFilterPartial.CurrentFilter = string.Empty,
                //        OperatorType operatorType ?? false,

            }

            ViewData["Title"] = "All Events";

            //var _facilities = new List<(int, string)> { (1, "OCC"), (2, "Diemer") }; //HttpContext.RequestServices.GetService<Application.Interfaces.IRepositories.IFacilityRepository>();

            //var _logTypes = new List<string> { "Clearance", "EOS", "FlowChange" }; //HttpContext.RequestServices.GetService<Application.Interfaces.IRepositories.ILogTypeRepository>();

            //ViewBag.Facilities = _facilities;
            //ViewBag.LogTypes = _logTypes;

            return View("Index", logFilterPartial);
        }

        [HttpGet]
        [Route("LogFilter")]
        public IActionResult LogFilter(_LogFilterPartialViewModel? logFilterPartial)
        {
            if (logFilterPartial is null)
            {
                logFilterPartial = new _LogFilterPartialViewModel
                {
                    SelectedFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo"),
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(1)
                };
                //logFilterPartial.CurrentFilter = string.Empty,
                //        OperatorType operatorType ?? false,

            }

            ViewData["Title"] = "All Events";
            return View("LogFilter", logFilterPartial);
        }
        [HttpPost]
        public IActionResult LogFilterSubmitted(_LogFilterPartialViewModel? logFilterPartial)
        {
            if (logFilterPartial is null)
            {
                logFilterPartial = new _LogFilterPartialViewModel
                {
                    SelectedFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo"),
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(1)
                };
                //logFilterPartial.CurrentFilter = string.Empty,
                //        OperatorType operatorType ?? false,

            }

            DateTime? startDate = logFilterPartial.StartDate;

            ViewData["Title"] = "All Events";
            return View("LogFilter", logFilterPartial);
        }

        // AJax method to get the log filter partial view
    }
}
