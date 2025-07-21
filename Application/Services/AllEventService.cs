using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AllEventService(IAllEventRepository allEventRepository) : IAllEventService
    {
        private readonly IAllEventRepository _allEventRepository = allEventRepository ?? throw new ArgumentNullException(nameof(allEventRepository));

        public Task<IEnumerable<ViewAllEventsCurrent>> GetAllEvents(int facilNo, DateOnly startDate, DateOnly endDate, string? keyword, bool primaryOperator)
        {
            var query = _allEventRepository.GetListQuery(facilNo, null, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), keyword, primaryOperator ? "Primary" : "Secondary");

            if (query == null || !query.Any())
            {
                return Task.FromResult<IEnumerable<ViewAllEventsCurrent>>(new List<ViewAllEventsCurrent>());
            }

            return Task.FromResult(query.AsEnumerable());
        }
    }
}
