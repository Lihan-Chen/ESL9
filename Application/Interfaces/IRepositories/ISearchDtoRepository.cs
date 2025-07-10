using Application.Dtos;

namespace Application.Interfaces.IRepositories
{
    public interface ISearchDtoRepository
    {
        public Task<List<SearchDto>> GetSearchDtoList(int facilNo, int logTypeNo, string startDate, string endDate, string operatorType, string optionAll, string searchValues);

        public Task<SearchDto> GetSearchDto(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);
    }
}
