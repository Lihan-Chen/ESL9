using Application.Interfaces.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Public.Controllers
{
    public class LogSearchController(IAllEventService allEventService,
                                     ICoreService coreService,
                                     ILogger<LogSearchController> logger) : _BaseController<LogSearchController>(coreService, logger)
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));
        //private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        private readonly ILogger<LogSearchController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public IActionResult Index()
        {
            return View();
        }
    }
}
