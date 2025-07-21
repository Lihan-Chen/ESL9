using Application.Dtos;
using Core.Models.BusinessEntities;

namespace Application.Interfaces.IServices
{
    public interface IAllEventService
    {
        // Get AllEventsCurrent by LogFilterPartialModel and facilNo, etc.
        public Task<IEnumerable<ViewAllEventsCurrent>> GetAllEvents(int facilNo, DateOnly startDate, DateOnly endDate, string? keyword, bool primaryOperator);

    }
}
