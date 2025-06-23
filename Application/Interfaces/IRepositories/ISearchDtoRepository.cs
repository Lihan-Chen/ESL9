using Application.Dtos;

namespace Application.Interfaces.IRepositories
{
    public interface ISearchDtoRepository
    {
        public Task<List<SearchDto>> GetSearchDTOList(int facilNo, int logTypeNo, string startDate, string endDate, string operatorType, string optionAll, string searchValues);

        public Task<SearchDto> GetSearchDTO(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);
    }
}
