using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Globalization;
using Microsoft.Extensions.Logging;
using Application.Interfaces.IRepositories;
using Core.Models.BusinessEntities;

namespace Infrastructure.DataAccess.Repositories
{
    public class AllEventRepository(EslDbContext context, EslViewContext view, ILogger<AllEventRepository> logger) : IAllEventRepository
    {
        protected readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        protected readonly EslViewContext _view = view ?? throw new ArgumentNullException(nameof(context));

        protected ILogger<AllEventRepository>? _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        protected DbSet<AllEvent> _dbSet = context.AllEvents;

        // Current_AllEvent
        protected DbSet<ViewAllEventsCurrent> _dbSetCurrent = view.ViewAllEventsCurrents;

        public IQueryable<ViewAllEventsCurrent> GetAllEventsCurrentQuery(int FacilNo)
        {
            return _dbSetCurrent.Where(x => x.FacilNo == FacilNo).AsNoTracking();

            //if (allEvents.Any())
            //{
            //    return allEvents;
            //}

            //return allEvents;
        }

        public IQueryable<AllEvent> GetDefaultAllEventsByFacil(int FacilNo, DateTime startDate, DateTime endDate)
        {
            return _dbSet.Where(x => x.FacilNo == FacilNo & x.EventDate >= startDate & x.EventDate <= endDate).AsNoTracking();
        }

        public IQueryable<AllEvent> GetByEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo) //, AllEvent? allEvent
        {
            return _dbSet.Where(x => x.FacilNo == FacilNo & x.LogTypeNo == LogTypeNo & x.EventID == EventID & x.EventID_RevNo == EventID_RevNo);

            //if (allEvent == null) return null;

            //return allEvent;
        }

        // refer to the Reference region below
        public IQueryable<AllEvent> FindEvents(Expression<Func<AllEvent, bool>> predicate) => _dbSet.AsNoTracking().Where(predicate);

        // TODO: consider using value objects for start-end daterange to capture business logic
        // ESL.ESL_AllEvents_Active_Proc
        public IQueryable<ViewAllEventsCurrent> GetListQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate, string strSearch, string strOperatorType)
        {
            DateTime _startDate;
            DateTime _endDate;
            string _dateFormat = "MM/dd/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;

            var query = _dbSetCurrent
                   .AsNoTracking()
                   .TagWith("GetListQuery");

            bool isValidStartDate = DateTime.TryParseExact(strStartDate, _dateFormat, provider, DateTimeStyles.None, out _startDate);
            bool isValidEndDate = DateTime.TryParseExact(strEndDate, _dateFormat, provider, DateTimeStyles.None, out _endDate);

            if (isValidStartDate && isValidEndDate && _endDate >= _startDate)
            {
                query = query.Where(a => a.EventDate >= _startDate && a.EventDate <= _endDate);
            }

            query = query.Where(a => (!facilNo.HasValue || a.FacilNo == facilNo) &&
                               (!logTypeNo.HasValue || a.LogTypeNo == logTypeNo) &&
                               (string.IsNullOrWhiteSpace(strOperatorType) || a.OperatorType == strOperatorType));

            query = query.Where(a => string.IsNullOrWhiteSpace(strSearch) ||
                               (a.Subject != null && a.Subject.Contains(strSearch, StringComparison.CurrentCultureIgnoreCase)) ||
                               (a.Details != null && a.Details.Contains(strSearch, StringComparison.CurrentCultureIgnoreCase)) ||
                               (a.EventID != null && a.EventID.Contains(strSearch, StringComparison.CurrentCultureIgnoreCase)) ||
                               (a.Notes != null && a.Notes.Contains(strSearch, StringComparison.CurrentCultureIgnoreCase)));

            return query.OrderByDescending(e => e.EventDate).ThenByDescending(u => u.UpdateDate);
        }

        public IQueryable<ViewAllEventsCurrent> GetItemQuery(int? facilNo, int? logTypeNo, string eventID, int? eventID_RevNo)
        {
            return _dbSetCurrent
               .AsNoTracking()
               .TagWith("GetItemQuery")
               .Where(a => a.EventID.Equals(eventID, StringComparison.CurrentCultureIgnoreCase) &&
                     (!facilNo.HasValue || a.FacilNo == facilNo.Value) &&
                     (!logTypeNo.HasValue || a.LogTypeNo == logTypeNo.Value) &&
                     (!eventID_RevNo.HasValue || a.EventID_RevNo == eventID_RevNo.Value));
        }

        public IQueryable<AllEvent> GetReportQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ViewAllEventsRelatedTo> GetSearch_RelatedToListQuery(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues)
        {
            throw new NotImplementedException();
        }

        // EslDetail is not the right entity.  it Should be the Details property of ViewAllEventCurrent
        public IQueryable<EslDetail> GetDetailsListQuery(int facilNo)
        {
            throw new NotImplementedException();
        }

        // EslDetail is not the right entity.  it Should be the Details property of ViewAllEventCurrent
        public IQueryable<EslSubject> GetSubjectListQuery(int facilNo)
        {
            throw new NotImplementedException();
        }

        #region private method

        private static DateTime To_Date(string strDate, string? strFormat)
        {
            if (strDate == null) return DateTime.MinValue;

            CultureInfo provider = CultureInfo.InvariantCulture;
            _ = DateTime.TryParseExact(strDate, strFormat, provider, DateTimeStyles.None, out DateTime _date);

            return _date;
        }

        #endregion

        //public async AllEvent? GetAllEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo)
        //{
        //    return await dbSet.FirstOrDefaultAsync(x => x.FacilNo == FacilNo & x.LogTypeNo == LogTypeNo & x.EventID == EventID & x.EventID_RevNo == EventID_RevNo);
        //}

        //public async Task<bool> AddAsync(AllEvent entity)
        //{
        //    await dbSet.AddAsync(entity); 
        //    return true;
        //}

        //public new Task<bool> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public new Task<IEnumerable<AllEvent>> FindAsync(Expression<Func<AllEvent, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<AllEvent>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<AllEvent> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> UpsertAsync(AllEvent entity)
        //{
        //    throw new NotImplementedException();
        //}

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
