using Application.Dtos;
using Application.Interfaces.IRepositories;
using Core.Models.BusinessEntities;
using Core.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Globalization;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.DataAccess.Repositories
{
    public class AllEventRepository(EslDbContext context, EslViewContext view, ILogger<AllEventRepository> logger) : IAllEventRepository
    {
        protected readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        protected readonly EslViewContext _view = view ?? throw new ArgumentNullException(nameof(context));

        protected ILogger<AllEventRepository>? _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        protected DbSet<AllEvent> _dbSet = context.AllEvents;

        // Current_AllEvent
        protected DbSet<ViewAllEventsCurrent> _dbSetCurrent = view.Current_AllEvents;

        public IQueryable<ViewAllEventsCurrent> GetAllEventsCurrentQuery(int facilNo) => _dbSetCurrent.Where(x => x.FacilNo == facilNo).AsNoTracking();

        public IQueryable<ViewAllEventsCurrent>? GetDefaultAllEventsCurrentByFacil(int facilNo, int? logTypeNo, DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("End Date must not be earlier than Start Date");
            }

            var query = _dbSetCurrent.Where(x => x.FacilNo == facilNo & x.EventDate >= startDate & x.EventDate <= endDate).AsNoTracking();

            if (logTypeNo != null)
            {
                query = query.Where(x => x.LogTypeNo == logTypeNo);
            }

            return query;
        }

        // refer to the Reference region below
        public IQueryable<AllEvent> FindEvents(Expression<Func<AllEvent, bool>> predicate) => _dbSet.AsNoTracking().Where(predicate);

        // TODO: consider using value objects for start-end daterange to capture business logic
        // ESL.ESL_AllEvents_Active_Proc
        public IQueryable<ViewAllEventsCurrent> GetListQuery(int facilNo, int? logTypeNo, DateTime startDate, DateTime endDate, string? strSearch, string strOperatorType)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("End Date must not be earlier than Start Date");
            }

            var baseQuery = GetDefaultAllEventsCurrentByFacil(facilNo, logTypeNo, startDate, endDate);

            if (baseQuery == null)
            {
                return Enumerable.Empty<ViewAllEventsCurrent>().AsQueryable();
            }

            var query = baseQuery.Where(a => a.OperatorType == strOperatorType)
                       .TagWith("GetListQuery");

            if (logTypeNo != null)
            {
                query = baseQuery.Where(a => a.LogTypeNo == logTypeNo);
            }

            if (strSearch != null)
            {
                string searchUpper = strSearch.ToUpperInvariant();
                query = query.Where(e =>
                    e.EventID!.Contains(strSearch, StringComparison.OrdinalIgnoreCase) ||
                    e.Subject!.Contains(strSearch, StringComparison.OrdinalIgnoreCase) ||
                    e.Details!.Contains(strSearch, StringComparison.OrdinalIgnoreCase) ||
                    e.UpdatedBy!.Contains(strSearch, StringComparison.OrdinalIgnoreCase) ||
                    //e.Notes!.Contains(strSearch, StringComparison.OrdinalIgnoreCase) ||
                    //e.FacilAbbr.Contains(strSearch, StringComparison.OrdinalIgnoreCase) ||
                    e.UpdateDate!.Contains(strSearch, StringComparison.OrdinalIgnoreCase)
                );
            }

            return query.OrderByDescending(e => e.EventDate).ThenByDescending(u => u.UpdateDate);
        }

        public IOrderedQueryable<ViewAllEventsCurrent> GetOrderedListQuery(int facilNo, int? logTypeNo, DateTime startDate, DateTime endDate, string strSearch, string strOperatorType, int? pageNo, int? pageSize)
        {
            var query = GetListQuery(facilNo, logTypeNo, startDate, endDate, strSearch, strOperatorType).OrderByDescending(o => o.EventDate).ThenByDescending(o => o.EventTime);

            if (pageNo.HasValue && pageSize.HasValue)
            {
                int skip = (pageNo.Value - 1) * pageSize.Value;
                query = (IOrderedQueryable<ViewAllEventsCurrent>)query.Skip(skip).Take(pageSize.Value);
            }
            else if (pageSize.HasValue)
            {
                query = (IOrderedQueryable<ViewAllEventsCurrent>)query.Take(pageSize.Value);
            }

            return query;
        }

        public IQueryable<ViewAllEventsCurrent> GetItemQuery(int facilNo, int logTypeNo, string eventID, int? eventID_RevNo)
        {
            return _dbSetCurrent.AsNoTracking()
               .TagWith("GetItemQuery")
               .Where(a => a.EventID.Equals(eventID, StringComparison.CurrentCultureIgnoreCase) &&
                     (a.FacilNo == facilNo) &&
                     (a.LogTypeNo == logTypeNo) &&
                     (a.EventID_RevNo == eventID_RevNo));
        }

        public async Task<IEnumerable<ViewAllEventsCurrent>> GetAlleventListProcedureAsync(
            int facilNo, int? logTypeNo, DateOnly? startDate, DateOnly? endDate, string? searchString, string? alert, int? pageNo = 1, int pageSize = 20, bool? operatorType = false)
        {
            //int inFacilNo = facilNo;

            //int inLogTypeNo = logTypeNo ?? 0;

            int _daysOffset = -1;

            string _stDtStr = startDate?.ToString("MM/dd/yyyy") ?? DateOnly.FromDateTime(DateTime.Now.AddDays(_daysOffset)).ToString("MM/dd/yyyy");

            string _enDtStr = endDate?.ToString("MM/dd/yyyy") ?? DateOnly.FromDateTime(DateTime.Now).ToString("MM/dd/yyyy");

            string _operatorType = operatorType == true ? "Primary" : "Secondary";

            int _page = pageNo ?? 0;

            DateOnly today = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

            DateOnly _enDt = endDate ?? DateOnly.FromDateTime(DateTime.Now).AddDays(1);
            DateOnly _stDt = startDate ?? _enDt.AddDays(_daysOffset); // for DateTime add .AddTicks(-1);

            // Must match the format of the input Date format
            //string _stDtStr = _stDt.ToString("MM/dd/yyyy");
            //string _enDtStr = _enDt.ToString("MM/dd/yyyy");

            var p_allEvents = new OracleParameter("allEventActiveCur", OracleDbType.RefCursor, ParameterDirection.Output);
            var p_facilNo = new OracleParameter("inFacilNo", OracleDbType.Int32, 2, facilNo, ParameterDirection.Input);
            var p_logTypeNo = new OracleParameter("inLogTypeNo", OracleDbType.Int32, 2, logTypeNo, ParameterDirection.Input);
            var p_startDate = new OracleParameter("inStartDate", OracleDbType.Varchar2, _stDtStr, ParameterDirection.Input);
            var p_endDate = new OracleParameter("inEndDate", OracleDbType.Varchar2, _enDtStr, ParameterDirection.Input);
            var p_operatorType = new OracleParameter("inOperatorType", OracleDbType.Varchar2, _operatorType, ParameterDirection.Input);

            //var sql = "BEGIN ESL.ESL_ALLEVENTS_ACTIVE_PROC(?, ?, ?, ?, ?, ?); END;"; Based on positional parameters as suggested by GitHub Copilot Chat - not working
            var sql = "BEGIN ESL.ESL_ALLEVENTS_ACTIVE_PROC(:inFacilNo, :inLogTypeNo, :inStartDate, :inEndDate, :inOperatorType, :allEventActiveCur); END;";

            var queryResult = await _dbSetCurrent.FromSqlRaw(sql, p_facilNo, p_logTypeNo, p_startDate, p_endDate, p_operatorType, p_allEvents).TagWith("ESL_ALLEVENTS_ACTIVE_PROC")
                              .ToListAsync();

            var result = queryResult.AsEnumerable();
            
            if (searchString != null)
            {
                string searchUpper = searchString.ToUpperInvariant();

                result = result.Where(e =>
                    e.EventID!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    e.Subject!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    e.Details!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    e.UpdatedBy!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    //e.Notes!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    //e.ClearanceID!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    e.UpdateDate!.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ).OrderByDescending(e => e.EventDate).ThenByDescending(u => u.UpdateDate);
            }


            //if (pageNo.HasValue && pageSize.HasValue)
            //{
            //    int skip = (pageNo.Value - 1) * pageSize.Value;
            //    return queryResult.Skip(skip).Take(pageSize.Value);
            //}
            //else if (pageSize.HasValue)
            //{
            //    return queryResult.Take(pageSize.Value);
            //}

            int skip = _page * pageSize;
            return result.Skip(skip).Take(pageSize);
        }

        public IQueryable<AllEvent> GetReportQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ViewAllEventsRelatedTo> GetSearch_RelatedToListQuery(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues)
        {
            throw new NotImplementedException(); // to be impplemented as needed when the related functionality is required
        }

        public IQueryable<ViewAllEventsCurrent> GetByEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo)
        {
            return _dbSetCurrent.Where(x => x.FacilNo == FacilNo & x.LogTypeNo == LogTypeNo & x.EventID == EventID & x.EventID_RevNo == EventID_RevNo).AsNoTracking();
        }

        public IQueryable<AllEventDetailsDto> GetAllEventDetails(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo)
        {
            string _CrLf = Environment.NewLine;
            return GetItemQuery(FacilNo, LogTypeNo, EventID, EventID_RevNo)
                .Select(x => new AllEventDetailsDto
                {
                    FacilNo = x.FacilNo,
                    LogTypeNo = x.LogTypeNo,
                    EventID = x.EventID,
                    EventID_RevNo = x.EventID_RevNo,
                    Subject = x.Subject,
                    Details = x.Details,
                    UpdatedBy = x.UpdatedBy!,
                    UpdateDate = DateTime.Parse(x.UpdateDate!) /*x.UpdateDate != null ? DateTime.Parse(x.UpdateDate) : DateTime.MinValue*/
                });
        }

        #region AllEvents

        // Update, Delete


        #endregion AllEvents








        //// EslDetail is not the right entity.  it Should be the Details property of ViewAllEventCurrent
        //public IQueryable<EslDetail> GetDetailsListQuery(int facilNo)
        //{
        //    throw new NotImplementedException();
        //}

        //// EslDetail is not the right entity.  it Should be the Details property of ViewAllEventCurrent
        //public IQueryable<EslSubject> GetSubjectListQuery(int facilNo)
        //{
        //    throw new NotImplementedException();
        //}

        #region private method

        private static DateTime To_Date(string strDate, string? strFormat)
        {
            if (strDate == null) return DateTime.MinValue;

            CultureInfo provider = CultureInfo.InvariantCulture;
            _ = DateTime.TryParseExact(strDate, strFormat, provider, DateTimeStyles.None, out DateTime _date);

            return _date;
        }

        #endregion

        #region Reference

        //public async Task<bool> DeleteAync(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo)
        //{
        //    try
        //    {
        //        var exist = await GetByIdAsync(FacilNo, LogTypeNo, EventID, EventID_RevNo);

        //        if (exist != null)
        //        {     
        //            dbSet.Remove(exist);
        //            return true;
        //        } else { return false;}
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(EmployeeRepository));
        //        return false;
        //    }
        //}


        // Ref: ?
        //public async Task<IList<OrderOverviewDto>> GetFilteredAsync(OrderQueryFilter filter)
        //{
        //    var orders = ordersRepository.GetQueryable()
        //        .AsNoTracking()
        //        .Include(s => s.User)
        //        .Include(x => x.OrderShipment)
        //        .Include(x => x.OrderPayment)
        //        .AsQueryable();

        //    if (filter.Id.HasValue)
        //    {
        //        var order = await orders.FirstOrDefaultAsync(s => s.Id == filter.Id.Value);

        //        if (order == null && filter.UserType == UserType.Admin)
        //        {
        //            throw new StreetwoodException(ErrorCode.OrderNotFound);
        //        }

        //        return mapper.Map<IList<OrderOverviewDto>>(new List<Order> { order });
        //    }

        //    if (filter.UserType == UserType.Customer)
        //    {
        //        orders = orders.Where(s => s.User.Id == filter.UserId);
        //    }

        //    if (filter.DateFrom.HasValue)
        //    {
        //        orders = orders.Where(s => s.CreationDateTime >= filter.DateFrom.Value);
        //    }

        //    if (filter.DateTo.HasValue)
        //    {
        //        orders = orders.Where(s => s.CreationDateTime <= filter.DateTo.Value);
        //    }

        //    if (filter.IsClosed.HasValue)
        //    {
        //        orders = orders.Where(s => s.IsClosed == filter.IsClosed);
        //    }

        //    if (filter.PaymentStatus.HasValue)
        //    {
        //        var paymentStatus = mapper.Map<PaymentStatusDto, PaymentStatus>(filter.PaymentStatus.Value);
        //        orders = orders.Where(s => s.OrderPayment.Status == paymentStatus);
        //    }

        //    if (filter.ShipmentStatus.HasValue)
        //    {
        //        var shipmentStatus = mapper.Map<ShipmentStatusDto, ShipmentStatus>(filter.ShipmentStatus.Value);
        //        orders = orders.Where(s => s.OrderShipment.Status == shipmentStatus);
        //    }

        //    orders = orders.OrderByDescending(x => x.CreationDateTime);

        //    if (filter.Take.HasValue)
        //    {
        //        orders = orders.Take(filter.Take.Value);
        //    }

        //    var ordersList = await orders
        //        .ToListAsync();
        //    return mapper.Map<IList<OrderOverviewDto>>(ordersList);
        //}

        #endregion
    }
}
