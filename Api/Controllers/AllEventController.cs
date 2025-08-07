using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllEventController(IAllEventService allEventService, ICoreService coreService, ILogger<AllEventController> logger) : ControllerBase
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));
        private readonly ILogger<AllEventController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet("GetAllEvents")]
        public IActionResult GetAllEvents(int facilNo, DateOnly startDate, DateOnly endDate, string? keyword, bool primaryOperator )
        {
            try
            {
                var events = _allEventService.GetAllEvents(facilNo, startDate, endDate, keyword, primaryOperator);

                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all events");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving events.");
            }
        }
    }
}
