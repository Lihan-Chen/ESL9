using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using Core.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllEventController(IAllEventService allEventService, ICoreService coreService, ILogger<AllEventController> logger) : ControllerBase
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));
        private readonly ILogger<AllEventController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        #region ESLCore

        int _daysOffset = -1;
        
        int _pageSize = 20;

        // GET: api/ViewAlleventsCurrents/5
        [HttpGet("AllEventsByFacility/{facilNo}")]
        //[Route("AllEvents")]
        public async Task<ActionResult<List<ViewAllEventsCurrent>>> GetAlleventList(int facilNo, int? logTypeNo, DateOnly? startDate, DateOnly? endDate, string? searchString, string? alert, int? page, bool? operatorType = false) // , string active, string sortOrder, string currentFilter, string searchString, int? page)
        {
            int _facilNo = facilNo;

            string _operatorType = (bool)operatorType ? "Primary" : "Secondary";

            int _page = page ?? 1;

            // _shiftNo = DateTime.Now

            DateOnly _enDt = endDate ?? DateOnly.FromDateTime(DateTime.Now).AddDays(1);

            DateOnly _stDt = startDate ?? _enDt.AddDays(_daysOffset); // for DateTime .AddTicks(-1);

            // Fix for CS0019: Convert DateOnly to DateTime for comparison with DateTime? type
            //var query = _context.ViewAlleventsCurrents.AsNoTracking()
            //    .TagWith("ESL.ESL_ALLEVENTS_ACTIVE_PROC")
            //    .Where(a => a.FacilNo == facilNo
            //                && a.EventDate >= _stDt.ToDateTime(TimeOnly.MinValue)
            //                && a.EventDate <= _enDt.ToDateTime(TimeOnly.MaxValue)
            //                && a.OperatorType == _operatorType);

            var queryResult = await _allEventService.GetAllEventsAsync(_facilNo, _stDt, _enDt, searchString, (bool)operatorType);
            
            if (logTypeNo != null)

            queryResult = queryResult.Where(e => e.LogTypeNo == logTypeNo);

            //if (searchString != null)
            //{
            //    queryResult = queryResult.Where(e => EF.Functions.Like(e.EventID.ToUpper(), searchString.ToUpper())
            //                          || EF.Functions.Like(e.Subject!.ToUpper(), searchString.ToUpper())
            //                          || EF.Functions.Like(e.Details!.ToUpper(), searchString.ToUpper()));
            //}

            var currentAllEvents = queryResult.OrderByDescending(o => o.EventDate).ThenByDescending(o => o.EventTime).Skip((_page -1)*_pageSize).Take(_pageSize);


            if (currentAllEvents == null)
            {
                return NotFound(alert);
            }

            return Ok(currentAllEvents.ToList());
        }

        // not used, revisit if necessary (EF Core version is better)
        [HttpGet("AllEventsByFacilityProcedure/{facilNo}")]
        public async Task<ActionResult<IEnumerable<ViewAllEventsCurrent>>> GetAlleventListProcedure(
            int facilNo, int? logTypeNo, DateOnly? startDate, DateOnly? endDate, string? searchString, string? alert, int? page, bool? operatorType = false)
        {
            int _facilNo = facilNo;
            string _operatorType = operatorType == true ? "Primary" : "Secondary";

            int _page = page ?? 0;

            DateOnly today = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

            DateOnly _enDt = endDate ?? DateOnly.FromDateTime(DateTime.Now).AddDays(1);
            DateOnly _stDt = startDate ?? _enDt.AddDays(_daysOffset); // for DateTime add .AddTicks(-1);

            // Must match the format of the input Date format
            string _stDtStr = _stDt.ToString("MM/dd/yyyy");
            string _enDtStr = _enDt.ToString("MM/dd/yyyy");

            var p_allEvents = new OracleParameter("allEventActiveCur", OracleDbType.RefCursor, ParameterDirection.Output);
            var p_facilNo = new OracleParameter("inFacilNo", OracleDbType.Int32, 2, facilNo, ParameterDirection.Input);
            var p_logTypeNo = new OracleParameter("inLogTypeNo", OracleDbType.Int32, 2, logTypeNo, ParameterDirection.Input);
            var p_startDate = new OracleParameter("inStartDate", OracleDbType.Varchar2, _stDtStr, ParameterDirection.Input);
            var p_endDate = new OracleParameter("inEndDate", OracleDbType.Varchar2, _enDtStr, ParameterDirection.Input);
            var p_operatorType = new OracleParameter("inOperatorType", OracleDbType.Varchar2, _operatorType, ParameterDirection.Input);

            //var sql = "BEGIN ESL.ESL_ALLEVENTS_ACTIVE_PROC(?, ?, ?, ?, ?, ?); END;"; Based on positional parameters as suggested by GitHub Copilot Chat - not working
            var sql = "BEGIN ESL.ESL_ALLEVENTS_ACTIVE_PROC(:inFacilNo, :inLogTypeNo, :inStartDate, :inEndDate, :inOperatorType, :allEventActiveCur); END;";

            var result = await _allEventService.GetAlleventListProcedureAsync(facilNo, logTypeNo, startDate, endDate, searchString, alert, page, 20, operatorType);

            //var result = await _context.ViewAlleventsCurrents.FromSqlRaw(sql, p_facilNo, p_logTypeNo, p_startDate, p_endDate, p_operatorType, p_allEvents).TagWith("ESL_ALLEVENTS_ACTIVE_PROC")
            //                .ToListAsync();

            //var result = await _context.ViewAlleventsCurrents.FromSqlRaw(sql, p_facilNo, p_logTypeNo, p_startDate, p_endDate, p_operatorType, p_allEvents).ToListAsync();
            // Stored procedure name must be all caps as shown.            
            //var result = await _context.ViewAlleventsCurrents.TagWith("ESL.ESL_ALLEVENTS_ACTIVE_PROC")
            //    .FromSqlRaw(
            //        "BEGIN ESL.ESL_ALLEVENTS_ACTIVE_PROC(:inFacilNo, :inLogTypeNo, :inStartDate, :inEndDate, :inOperatorType, :allEventActiveCur); END;",
            //        [p_facilNo, p_logTypeNo, p_startDate, p_endDate, p_operatorType, p_allEvents])
            //    .ToListAsync();



            if (result == null || !result.Any())
            {
                return NotFound(alert);
            }

            return Ok(result);
        }

        #endregion ESLCore





        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEventsAsync(int facilNo, DateOnly startDate, DateOnly endDate, string? strSearch, bool primaryOperator)
        {
            try
            {
                var events = await _allEventService.GetAllEventsAsync(facilNo, startDate, endDate, strSearch, primaryOperator);

                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all events");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving events.");
            }
        }

        [HttpGet("GetAllEventDetails")]
        public IActionResult GetAllEventDetails(int? facilNo, int? logTypeNo, string eventID, int? eventID_RevNo)
        {
            try
            {
                var eventDetails = _allEventService.GetAllEventDetails(facilNo, logTypeNo, eventID, eventID_RevNo);
                return Ok(eventDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving this event details");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving event details.");
            }
        }

        [HttpGet("GetAllEventsByFacilNo")]
        public async Task<IActionResult> GetAllEventByFacilNo(int facilNo, int? logTypeNo)
        {
            try
            {
                var events = await _allEventService.GetAllEvents(facilNo, logTypeNo);
                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving events by facility number");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving events.");
            }
        }

        // GetDefaultAllEventsByFacil(int FacilNo, DateTime startDate, DateTime endDate)
        [HttpGet("GetAllCurrentEventsByFacilNo")]
        public async Task<IActionResult> GetAllEventByFacilNo(int facilNo, int? logTypeNo, DateTime startDate, DateTime endDate)
        {
            try
            {
                var events = await _allEventService.GetDefaultAllEventsByFacil(facilNo, startDate, endDate);
                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving events by facility number");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving events.");
            }
        }

        // GetItemQuery(int? facilNo, int? logTypeNo, string eventID, int? eventID_RevNo)
        [HttpGet("GetEvent")]
        public async Task<IActionResult> GetEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            try
            {
                var eventItem = await _allEventService.GetEvent(facilNo, logTypeNo, eventID, eventID_RevNo);
                return Ok(eventItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving event");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the event.");
            }
        }
    }
}
