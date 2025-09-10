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

        public async Task<IEnumerable<ViewAllEventsCurrent>> GetAllEventsAsync(int facilNo, DateOnly startDate, DateOnly endDate, string? strSearch, bool primaryOperator)
        {
            var query = _allEventRepository.GetListQuery(facilNo, null, startDate.ToDateTime(TimeOnly.MinValue), endDate.ToDateTime(TimeOnly.MaxValue), strSearch ?? string.Empty, primaryOperator ? "Primary" : "Secondary"); // "MM/dd/yyyy"
            if (query == null || !query.Any())
            {
                return await Task.FromResult<IEnumerable<ViewAllEventsCurrent>>(new List<ViewAllEventsCurrent>());
            }
            return await Task.FromResult(query.AsEnumerable());
        }

        public async Task<IEnumerable<ViewAllEventsCurrent>> GetAllEventsAsync(int facilNo, /*int? logTypeNo,*/ DateOnly startDate, DateOnly endDate, string? strSearch, bool primaryOperator, int? pageNo, int? pageSize)
        {
            // GetAllEventsAsync
            // var query = _allEventRepository.GetListQuery(facilNo, null, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), keyword, primaryOperator ? "Primary" : "Secondary"); // "MM/dd/yyyy"
            var orderedQuery = _allEventRepository.GetOrderedListQuery(facilNo, null, startDate.ToDateTime(TimeOnly.MinValue), endDate.ToDateTime(TimeOnly.MaxValue), strSearch ?? string.Empty, primaryOperator ? "Primary" : "Secondary", pageNo, pageSize); // "MM/dd/yyyy"

            if (orderedQuery == null || !orderedQuery.Any())
            {
                return await Task.FromResult<IEnumerable<ViewAllEventsCurrent>>(new List<ViewAllEventsCurrent>());
            }

            return await Task.FromResult(orderedQuery.AsEnumerable());
        }

        

        public async Task<AllEventDetailsDto> GetAllEventDetails(int? facilNo, int? logTypeNo, string? eventID, int? eventID_RevNo) //GetAllEventDetails
        {
            if (facilNo == null || logTypeNo == null || string.IsNullOrEmpty(eventID) || eventID_RevNo == null)
            {
                return new AllEventDetailsDto();
            }

            var query = _allEventRepository.GetAllEventDetails(facilNo.Value, logTypeNo.Value, eventID!, eventID_RevNo.Value).FirstOrDefault();

            if (query == null)
            {
                return await Task.FromResult<AllEventDetailsDto>(new AllEventDetailsDto());
            }

            return await Task.FromResult(query);
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
            var query = _allEventRepository.GetDefaultAllEventsCurrentByFacil(facilNo, null, startDate, endDate).OrderByDescending(a => a.EventDate).Skip(0).Take(20);
            return Task.FromResult(query.AsEnumerable());
        }

        //public async Task<IEnumerable<ViewAllEventsCurrent>> GetDefaultAllEventsByFacil(int facilNo, int? logTypeNo, DateOnly startDate, DateOnly endDate, string? searchString, int? page, bool? operatorType = false) // , string active, string sortOrder, string currentFilter, string searchString, int? page)
        //{
        //{
        //    var query = await _allEventRepository.GetDefaultAllEventsByFacil(facilNo, startDate, endDate).OrderByDescending(a => a.EventDate).Skip(0).Take(20);
        //    return Task.FromResult(query.AsEnumerable());
        //}

        public Task<ViewAllEventsCurrent?> GetEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            var query = _allEventRepository.GetItemQuery(facilNo, logTypeNo, eventID, eventID_RevNo).FirstOrDefault();
            return Task.FromResult(query);
        }

        public async Task<IEnumerable<ViewAllEventsCurrent>> GetAlleventListProcedureAsync(int facilNo, int? logTypeNo, DateOnly? startDate, DateOnly? endDate, string? searchString, string? alert, int? pageNo = 1, int pageSize = 20, bool? operatorType = false)
        {
            return await _allEventRepository.GetAlleventListProcedureAsync(facilNo, logTypeNo, startDate, endDate, searchString, null, /*operatorType == true ? "Primary" : "Secondary",*/ pageNo, pageSize, operatorType).ContinueWith(t => t.Result.ToList());
        }        
    }
}
