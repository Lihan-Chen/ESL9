using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Mvc.Controllers;

namespace Mvc.Areas.Public.Controllers
{
    public class AllEventsViewerController(IAllEventService allEventService, ICoreService coreService, /*IHttpContextAccessor httpContextAccessor,*/ ILogger<AllEventsViewerController> logger) : _BaseController<AllEventsViewerController>(coreService, logger)
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));
        //private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        private readonly ILogger<AllEventsViewerController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
