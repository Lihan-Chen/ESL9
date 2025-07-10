using Application.Dtos;
using Application.Interfaces.IRepositories;
using Infrastructure.DataAccess;
using Microsoft.Extensions.Logging;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public class SearchDtoRepository(EslDbContext context, ILogger<SearchDtoRepository> logger) : ISearchDtoRepository
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<SearchDtoRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public Task<SearchDto> GetSearchDto(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            //SearchDTO _searchDTO = new SearchDTO();

            //string _sql = "SELECT A.FACILNO, B.FACILNAME, A.LOGTYPENO, C.LOGTYPENAME, A.EVENTID, A.EVENTID_REVNO, A.EVENTDATE, A.EVENTTIME, A.SUBJECT, A.DETAILS, A.UPDATEDBY, A.UPDATEDATE ";
            //// _sql += "FROM ESL.ESL_ALLEVENTS A, ";
            ////_sql += "FROM ESL.VIEW_ALLEVENTS_CURRENT A, ";
            //_sql += "FROM ESL.VIEW_SEARCH_ALLEVENTS A, ";
            //_sql += "ESL.ESL_FACILITIES B, ";
            //_sql += "ESL.ESL_LOGTYPES C ";

            ////_sql += "WHERE "

            //_sql += "WHERE A.FACILNO = '" + facilNo.ToString() + "' AND ";

            //if (logTypeNo != 0)
            //{
            //    _sql += "A.LOGTYPENO = '" + logTypeNo.ToString() + "' AND ";
            //}

            //_sql += "A.EVENTID = '" + eventID + "' AND ";
            //_sql += "A.EVENTID_REVNO = " + eventID_RevNo.ToString(); // +" AND ";

            //return Task.FromResult(_searchDTO);

            throw new NotImplementedException();
        }

        public Task<List<SearchDto>> GetSearchDtoList(int facilNo, int logTypeNo, string startDate, string endDate, string operatorType, string optionAll, string searchValues)
        {
            throw new NotImplementedException();
        }
    }
}
