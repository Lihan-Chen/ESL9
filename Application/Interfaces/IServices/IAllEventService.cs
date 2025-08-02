using Application.Dtos;
using Core.Models.BusinessEntities;

namespace Application.Interfaces.IServices
{
    public interface IAllEventService
    {
        // Get AllEventsCurrent by LogFilterPartialModel and facilNo, etc.
        public Task<IEnumerable<ViewAllEventsCurrent>> GetAllEvents(int facilNo, DateOnly startDate, DateOnly endDate, string? keyword, bool primaryOperator);

        #region mvc4esl

        public Task<IEnumerable<ViewAllEventsCurrent>> GetList(int facilNo, int logTypeNo, string startDate, string endDate, string operatorType);

        public Task<IEnumerable<RptAllEvent>> GetReport(int facilNo, string strStartDate, string strEndDate);

        #endregion mvc4esl
    }
}
