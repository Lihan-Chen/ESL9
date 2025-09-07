using Application.Dtos;
using Core.Models.BusinessEntities;

namespace Application.Interfaces.IServices
{
    public interface IAllEventService
    {
        // Get AllEventsCurrent by LogFilterPartialModel and facilNo, etc.
        public Task<IEnumerable<ViewAllEventsCurrent>> GetAllEvents(int facilNo, DateOnly startDate, DateOnly endDate, string? keyword, bool primaryOperator);

        public Task<IEnumerable<ViewAllEventsCurrent>> GetAllEventsAsync(int facilNo, DateOnly startDate, DateOnly endDate, string? keyword, bool primaryOperator);

        public Task<AllEventDetailsDto> GetAllEventDetails(int? facilNo, int? logTypeNo, string? eventID, int? eventID_RevNo);

        #region mvc4esl

        public Task<IEnumerable<ViewAllEventsCurrent>> GetList(int facilNo, int logTypeNo, string startDate, string endDate, string? keyword, string operatorType);

        public Task<IEnumerable<RptAllEvent>> GetReport(int facilNo, string strStartDate, string strEndDate);

        #endregion mvc4esl

        public Task<IEnumerable<ViewAllEventsCurrent>> GetAllEvents(int facilNo, int? logTypeNo);

        public Task<IEnumerable<ViewAllEventsCurrent>> GetDefaultAllEventsByFacil(int facilNo, DateTime startDate, DateTime endDate);

        public Task<ViewAllEventsCurrent?> GetEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);
    }
}
