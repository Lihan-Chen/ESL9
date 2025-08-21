using Application.Interfaces.IRepositories;
using Core.Models.BusinessEntities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DataAccess.Repositories
{
    public class LogTypeRepository(
            EslDbContext context,
            ILogger<LogTypeRepository> logger
            ) : ILogTypeRepository
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<LogTypeRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public IOrderedQueryable<LogType> GetLogTypes() => _context.LogTypes.AsNoTracking().OrderBy(l => l.LogTypeNo);

        public IQueryable<LogType> GetLogType(int LogTypeNo) => this.GetLogTypes().Where(l => l.LogTypeNo == LogTypeNo);

        public IQueryable<LogType> GetLogType(string LogTypeName) => this.GetLogTypes().Where(l => l.LogTypeName == LogTypeName);
        
        public IQueryable<string> GetLogTypeName(int LogTypeNo) => this.GetLogType(LogTypeNo).Select(t => t.LogTypeName);

        public IQueryable<int> GetLogTypeNo(string LogTypeName) => this.GetLogType(LogTypeName).Select(t => t.LogTypeNo);

        public IOrderedQueryable<string> GetLogTypeList()
        { 
            var query = _context.LogTypes.AsNoTracking().OrderBy(l => l.LogTypeNo);

            var excludedTypes = new List<string> { "All-Events", "Clearance Transfer" };

            return (IOrderedQueryable<string>)this.GetLogTypes().Where(f => !excludedTypes.Contains(f.LogTypeName)).Select(l => l.LogTypeName);
        }

        
        //var logTypeList = await GetLogTypes();
        //// return new SelectList(logTypeList, "LogTypeNo", "LogTypeName");
        //return new SelectList(logTypeList, nameof(LogType.LogTypeNo), nameof(LogType.LogTypeName));
        //}
    }
}
