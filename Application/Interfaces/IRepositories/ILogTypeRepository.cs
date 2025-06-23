using Core.Models.BusinessEntities;

namespace Application.Interfaces.IRepositories
{
    public interface ILogTypeRepository
    {
        // LogType GetItem(int logTypeNo)
        public IQueryable<LogType> GetLogType(int LogTypeNo);

        // LogType GetItem(int logTypeNo)
        public IQueryable<LogType> GetLogType(string LogTypeName);

        // LogList GetList() ~ GetLogList
        public IOrderedQueryable<LogType> GetLogTypes();

        public IQueryable<string> GetLogTypeName(int LogTypeNo);
       
        public IQueryable<int> GetLogTypeNo(string LogTypeName);

        // GetLogTypeList() for selectItem (LogTypeNo, LogTypeName)
        public IOrderedQueryable<string> GetLogTypeList();
    }
}