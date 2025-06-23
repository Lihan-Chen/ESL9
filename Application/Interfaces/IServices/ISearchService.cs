using Application.Dtos;

namespace Application.Interfaces.IServices
{
    public interface ISearchService
    {
        public Task<SearchDto?> GetSearchDTO(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

        public Task<List<SearchDto>> GetSearchDTOList(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues);
    }
}
