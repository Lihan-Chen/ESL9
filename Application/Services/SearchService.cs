using Application.Dtos;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;

namespace Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchDtoRepository _searchRepo;

        public SearchService(ISearchDtoRepository searchRepo)
        {
            _searchRepo = searchRepo;
        }

        public Task<SearchDto?> GetSearchDTO(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        {
            throw new NotImplementedException();
        }

        public Task<List<SearchDto>> GetSearchDTOList(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues)
        {
            throw new NotImplementedException();
        }

        #region Private functions
        /// <summary>
        /// Processes the searchValues into searchLog for getList.
        /// </summary>
        private static string searchLog(string searchValues, string optionAll)
        {
            // TODO: need regex function 

            //Convert to uppercase then split into array of string
            String _searchValues = searchValues.Trim().ToUpper().Replace(" ", "%");
            String[] _arraySearchValues = _searchValues.Split('%', '*', '$', '&', '#'); // , '[^\W\d](\w|[-']{1,2}(?=\w))*');  [a-zA-Z0-9] for word only

            // String _sql;
            // String strWhere = "WHERE (UPPER(Details || ' ' || Subject) LIKE '%";
            String strWhere = "(UPPER(Details || ' ' || Subject) LIKE '%";
            String _andOr;

            optionAll = optionAll.ToUpper() != "AND" ? "OR" : optionAll;
            _andOr = " " + optionAll + " "; // == " ? " AND " : " OR "; 
            // bool blnFirst = true;

            // AND OR
            foreach (string searchItem in _arraySearchValues)
            {
                if (!String.IsNullOrWhiteSpace(searchItem)) // if (searchItem != null)
                {
                    if (searchItem == _arraySearchValues[0])
                    {
                        strWhere += searchItem;
                        strWhere += "%'";
                    }
                    else
                    {
                        strWhere += _andOr;
                        strWhere += "UPPER(Details || ' ' || Subject) LIKE '%";
                        strWhere += searchItem;
                        strWhere += "%'";
                    }
                }

            }

            strWhere += ") ";

            return strWhere;
        }

        #endregion
    }
}
