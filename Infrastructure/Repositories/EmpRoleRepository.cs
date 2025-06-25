using Application.Interfaces.IRepositories;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public class EmpRoleRepository(EslDbContext context,
            ILogger<EmpRoleRepository> logger
            ) : IEmpRoleRepository
    {
        protected readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        protected readonly ILogger<EmpRoleRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<string?> GetRole(string userID, int? facilNo)
        {
            if (facilNo is null)
            {
                return await _context.UserRoles.Where(r => r.UserID == userID).OrderBy(o => o.FacilNo).Select(s => s.Role ?? string.Empty).FirstOrDefaultAsync();
            }

            return await _context.UserRoles.Where(r => r.UserID == userID && r.FacilNo == facilNo).Select(s => s.Role ?? string.Empty).FirstOrDefaultAsync();
        }

        public bool IsInRole(string userID, string role, int? facilNo)
        {
            if (facilNo == null)
            {
                return _context.UserRoles.Any(r => r.UserID == userID && r.Role == role);
            }

            return _context.UserRoles.Any(r => r.UserID == userID && r.Role == role && r.FacilNo == facilNo);
        }
    }
}
