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
    public class AllEventsViewerController(IAllEventService allEventService, ICoreService coreService, ILogger<AllEventController> logger) : ControllerBase
    {
        private readonly IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));
        private readonly ILogger<AllEventController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        int _facilNo;
        string _operatorType;
        const int _pageSize = 20;
        const int _daysOffset = -2;


        #region ESLCore

        // GET: api/ViewAlleventsCurrents/5
        [HttpGet("AllEventsByFacility/{facilNo}")]
        public async Task<ActionResult<List<ViewAllEventsCurrent>>> GetAlleventList(int facilNo, int? logTypeNo, DateOnly? startDate, DateOnly? endDate, string? searchString, string? alert, int? pageNo = 1, int? pageSize = _pageSize, bool operatorType = false)
        {
            _facilNo = facilNo;

            if (endDate != null && startDate != null && endDate < startDate)
            {
                return BadRequest("End Date must be greater than or equal to Start Date.");
            }

            DateOnly _enDt = endDate ?? DateOnly.FromDateTime(DateTime.Now).AddDays(1);
            DateOnly _stDt = startDate ?? _enDt.AddDays(_daysOffset);

            var currentAllEventsEnumerable = await _allEventService.GetAllEventsAsync(facilNo, _stDt, _enDt, searchString, operatorType, pageNo, pageSize);

            if (currentAllEventsEnumerable == null)
            {
                return NotFound(alert);
            }

            var currentAllEvents = currentAllEventsEnumerable.ToList();

            return currentAllEvents;
        }

        // not used, revisit if necessary (EF Core version is better)
        [HttpGet("AllEventsByFacilityProcedure/{facilNo}")]
        public async Task<ActionResult<IEnumerable<ViewAllEventsCurrent>>> GetAlleventListProcedure(
            int facilNo, int? logTypeNo, DateOnly? startDate, DateOnly? endDate, string? searchString, string? alert, int? page, bool? operatorType = false)
        {
            //_facilNo = facilNo;

            //_operatorType = operatorType == true ? "Primary" : "Secondary";

            int _page = page ?? 1;

            int pageSize = 20;

            //DateOnly today = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

            //DateOnly _enDt = endDate ?? DateOnly.FromDateTime(DateTime.Now).AddDays(1);
            //DateOnly _stDt = startDate ?? _enDt.AddDays(_daysOffset); // for DateTime add .AddTicks(-1);

            //// Must match the format of the input Date format
            //string _stDtStr = _stDt.ToString("MM/dd/yyyy");
            //string _enDtStr = _enDt.ToString("MM/dd/yyyy");

            //var p_allEvents = new OracleParameter("allEventActiveCur", OracleDbType.RefCursor, ParameterDirection.Output);
            //var p_facilNo = new OracleParameter("inFacilNo", OracleDbType.Int32, 2, facilNo, ParameterDirection.Input);
            //var p_logTypeNo = new OracleParameter("inLogTypeNo", OracleDbType.Int32, 2, logTypeNo, ParameterDirection.Input);
            //var p_startDate = new OracleParameter("inStartDate", OracleDbType.Varchar2, _stDtStr, ParameterDirection.Input);
            //var p_endDate = new OracleParameter("inEndDate", OracleDbType.Varchar2, _enDtStr, ParameterDirection.Input);
            //var p_operatorType = new OracleParameter("inOperatorType", OracleDbType.Varchar2, _operatorType, ParameterDirection.Input);

            ////var sql = "BEGIN ESL.ESL_ALLEVENTS_ACTIVE_PROC(?, ?, ?, ?, ?, ?); END;"; Based on positional parameters as suggested by GitHub Copilot Chat - not working
            //var sql = "BEGIN ESL.ESL_ALLEVENTS_ACTIVE_PROC(:inFacilNo, :inLogTypeNo, :inStartDate, :inEndDate, :inOperatorType, :allEventActiveCur); END;";

            ////var result = await _context.ViewAlleventsCurrents.FromSqlRaw(sql, p_facilNo, p_logTypeNo, p_startDate, p_endDate, p_operatorType, p_allEvents).TagWith("ESL_ALLEVENTS_ACTIVE_PROC")
            //                .ToListAsync();

            var result = await _allEventService.GetAlleventListProcedureAsync(facilNo, logTypeNo, startDate, endDate, searchString, alert, page, pageSize, operatorType);

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
    }
}
