using Application.Dtos;
using Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IAllEventRepository // : IEventRepository<AllEvent>
    {
        public IQueryable<ViewAllEventsCurrent> GetAllEventsCurrentQuery(int facilNo);

        public IQueryable<ViewAllEventsCurrent>? GetDefaultAllEventsCurrentByFacil(int facilNo, int? logTypeNo, DateTime startDate, DateTime endDate);

        // EF version of "ESL.ESL_ALLEVENTS_ACTIVE_PROC";
        public IQueryable<ViewAllEventsCurrent> GetListQuery(int facilNo, int? logTypeNo, DateTime startDate, DateTime endDate, string strSearch, string strOperatorType);

        // EF version of "ESL.ESL_ALLEVENTS_ACTIVE_PROC";
        public IOrderedQueryable<ViewAllEventsCurrent> GetOrderedListQuery(int facilNo, int? logTypeNo, DateTime startDate, DateTime endDate, string strSearch, string strOperatorType, int? pageNo, int? pageSize);

        public IQueryable<ViewAllEventsCurrent> GetItemQuery(int facilNo, int logTypeNo, string eventID, int? eventID_RevNo);

        //public IQueryable<ViewAllEventsCurrent> GetByEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

        #region Stored Procedure Names

        // _sql = ESL.ESL_AllEvents_Active_Proc
        public Task<IEnumerable<ViewAllEventsCurrent>> GetAlleventListProcedureAsync(
            int facilNo, int? logTypeNo, DateOnly? startDate, DateOnly? endDate, string? searchString, string? alert, int? pageNo = 1, int pageSize = 20, bool? operatorType = false);


        // _sql = "ESL.ESL_RPT_ALLEVENTS_PROC"; 
        public IQueryable<AllEvent> GetReportQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate);

        // _sql = "ESL.ESL_ALLEVENTS_RELATEDTO_PROC";
        public IQueryable<ViewAllEventsRelatedTo> GetSearch_RelatedToListQuery(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues);

        #endregion Stored Procedure Names

        public IQueryable<AllEventDetailsDto> GetAllEventDetails(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

        public IQueryable<AllEvent> FindEvents(Expression<Func<AllEvent, bool>> predicate);

        
        //// _sql = "ESL.ESL_DETAILSLIST_PROC";
        //public IQueryable<EslDetail> GetDetailsListQuery(int facilNo);

        //// string _sql = "ESL.ESL_SUBJECTLIST_PROC";
        //public IQueryable<EslSubject> GetSubjectListQuery(int facilNo);

        //Task<bool> AddEvent(AllEvent allEvent);

        // Soft Delete
        //Task<bool> DeleteEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

        // Mark the original entiry as revised or modified, and create a new entity with new revision number
        //Task<bool> Upsert(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo, AllEvent allEvent);
    }
}
