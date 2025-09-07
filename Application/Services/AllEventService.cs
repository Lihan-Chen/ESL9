using Application.Dtos;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ViewAllEventsCurrent>> GetAllEvents(int facilNo, DateOnly startDate, DateOnly endDate, string? keyword, bool primaryOperator)
        {
            // var query = _allEventRepository.GetListQuery(facilNo, null, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), keyword, primaryOperator ? "Primary" : "Secondary"); // "MM/dd/yyyy"
            var query = _allEventRepository.GetListQuery(facilNo, null, startDate.ToDateTime(TimeOnly.MinValue), endDate.ToDateTime(TimeOnly.MaxValue), keyword ?? string.Empty, primaryOperator ? "Primary" : "Secondary"); // "MM/dd/yyyy"

            if (query == null || !query.Any())
            {
                return await Task.FromResult<IEnumerable<ViewAllEventsCurrent>>(new List<ViewAllEventsCurrent>());
            }

            return await Task.FromResult(query.AsEnumerable());
        }

        public async Task<AllEventDetailsDto> GetAllEventDetails(int? facilNo, int? logTypeNo, string? eventID, int? eventID_RevNo) //GetAllEventDetails
        {
            if(facilNo == null || logTypeNo == null || string.IsNullOrEmpty(eventID) || eventID_RevNo == null)
            {
                return new AllEventDetailsDto();
            }
            
            var query = _allEventRepository.GetAllEventDetails((int)facilNo!, (int)logTypeNo!, eventID!, (int)eventID_RevNo!).FirstOrDefault();

            if (query == null)
            {
                return await Task.FromResult<AllEventDetailsDto>(new AllEventDetailsDto());
            }

            return await Task.FromResult(query);
        }

        // _dbSetCurrent.Where(x => x.FacilNo == FacilNo & x.EventDate >= startDate & x.EventDate <= endDate).AsNoTracking();
        public async Task<IEnumerable<ViewAllEventsCurrent>> GetAllEventsAsync(int facilNo, DateOnly startDate, DateOnly endDate, string? keyword, bool primaryOperator)
        {
            var query = _allEventRepository.GetListQuery(facilNo, null, startDate.ToDateTime(TimeOnly.MinValue), endDate.ToDateTime(TimeOnly.MaxValue), keyword ?? string.Empty, primaryOperator ? "Primary" : "Secondary"); // "MM/dd/yyyy"

            if (query == null || !query.Any())
            {
                return await Task.FromResult<IEnumerable<ViewAllEventsCurrent>>(new List<ViewAllEventsCurrent>());
            }

            return await Task.FromResult(query.AsEnumerable());
        }

        public async Task<IEnumerable<ViewAllEventsCurrent>> GetList(int facilNo, int logTypeNo, string startDate, string endDate, string? keyword, string operatorType)
        {
            DateOnly _startDate = DateOnly.Parse(startDate);
            DateOnly _endDate = DateOnly.Parse(endDate);

            var query = _allEventRepository.GetListQuery(facilNo, null, _startDate.ToDateTime(TimeOnly.MinValue), _endDate.ToDateTime(TimeOnly.MaxValue), keyword ?? string.Empty, operatorType ?? "Primary"); // "MM/dd/yyyy"

            if (query == null || !query.Any())
            {
                return await Task.FromResult<IEnumerable<ViewAllEventsCurrent>>(new List<ViewAllEventsCurrent>());
            }

            return await Task.FromResult(query.AsEnumerable());
        }

        public Task<IEnumerable<RptAllEvent>> GetReport(int facilNo, string strStartDate, string strEndDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ViewAllEventsCurrent>> GetAllEvents(int facilNo, int? logTypeNo)
        {
            var query = _allEventRepository.GetAllEventsCurrentQuery(facilNo).Where(a => a.LogTypeNo == logTypeNo || logTypeNo == null).Where(d => d.EventDate >= DateTime.Parse("2020-10-11 14:36:05")).OrderByDescending(a => a.EventDate).Skip(0).Take(20);
            return Task.FromResult(query.AsEnumerable());
        }

        // GetDefaultAllEventsByFacil(int FacilNo, DateTime startDate, DateTime endDate)
        public Task<IEnumerable<ViewAllEventsCurrent>> GetDefaultAllEventsByFacil(int facilNo, DateTime startDate, DateTime endDate)
        {
            var query = _allEventRepository.GetDefaultAllEventsByFacil(facilNo, startDate, endDate).OrderByDescending(a => a.EventDate).Skip(0).Take(20);
            return Task.FromResult(query.AsEnumerable());
        }

        public Task<ViewAllEventsCurrent?> GetEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            var query = _allEventRepository.GetByEvent(facilNo, logTypeNo, eventID, eventID_RevNo).FirstOrDefault();
            return Task.FromResult(query);
        }
    }
}
