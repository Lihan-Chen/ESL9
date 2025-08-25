using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
    [Authorize]
    public class AllEventController(IAllEventService allEventService, ICoreService coreService, /*IHttpContextAccessor httpContextAccessor,*/ ILogger < AllEventController> logger) : BaseController<AllEventController>(coreService, logger)
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));
        //private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        private readonly ILogger<AllEventController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        // GET: /AllEvents/
        int? _facilNo;
        //int _logTypeNo;
        string _eventID = string.Empty; // = string.Empty;
        int _eventID_RevNo;
        string _facilName = string.Empty;
        //string _logTypeName;
        string? _startDate;
        string? _endDate;
        DateOnly? initialStartDate;
        string _operatorType = String.Empty;
        bool _opType = true;
        
        DateOnly tomorrow = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        int _daysOffSet = -2;

        public IActionResult Index([FromBody] _LogFilterPartialViewModel? logFilterPartial, int? facilNo, DateOnly? startDate, DateOnly? endDate, string? searchString, int? page, bool? operatorType)
        {
            //HttpContext? httpContext = _httpContextAccessor.HttpContext;

            //if (httpContext != null && httpContext.User != null && httpContext.User.Identity.IsAuthenticated)

            ISession session = HttpContext!.Session;

            _facilNo = logFilterPartial?.SelectedFacilNo ?? facilNo ?? FacilNo;

            var facility = _coreService.GetFacility(_facilNo).Result;
            
            if (_facilNo == null || facility == null)
            {
                _logger.LogError("Facility not found for facilNo: {FacilNo}", _facilNo);
                return NotFound("Facility not found.");
            }
            _facilName = facility?.FacilName ?? string.Empty;

            string _shiftNo = session.GetString("ShiftNo");
                 //  == "Day" ? 1 : 2;

            // Set up default values
            DateOnly _enDt = logFilterPartial?.EndDate ?? endDate ?? tomorrow; // now.Date; 
            DateOnly? _stDt = logFilterPartial?.StartDate ?? startDate ?? _enDt.AddDays(_daysOffSet); //initialStartDate; 

            session.SetString("startDate", _stDt.ToString() ?? string.Empty);

            if (_stDt.HasValue)
            {
                session.SetString("endDate", _enDt.ToString());
            }

            searchString = !String.IsNullOrEmpty(logFilterPartial?.CurrentFilter) ? logFilterPartial.CurrentFilter : searchString;

            _opType = operatorType.HasValue || logFilterPartial.OperatorType;

            // _shiftNo = System.Web.HttpContext.Current.Session["ShiftNo"].ToString() == "Day" ? 1 : 2;

            //var facilAbbrList = GetFacilAbbrList();
            //var logTypeNames = GetLogTypeNames();

            if (logFilterPartial is null)
            {
                logFilterPartial = new _LogFilterPartialViewModel
                {
                    SelectedFacilNo = base.HttpContext.Session.GetInt32("SelectedFacilNo"),
                    //SelectedLogTypeNo = _httpContext.Session.GetInt32("SelectedLogTypeNo");
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
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
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
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
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1))
                };
                //logFilterPartial.CurrentFilter = string.Empty,
                //        OperatorType operatorType ?? false,

            }

            DateOnly? startDate = logFilterPartial.StartDate;

            ViewData["Title"] = "All Events";
            return View("LogFilter", logFilterPartial);
        }

        // AJax method to get the log filter partial view
    }
}
