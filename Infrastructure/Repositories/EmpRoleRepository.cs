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

        // output parameter of string rolename if exists or null regardless if facilNo is null or not
        public async Task<string?> GetRole(string userID, int? facilNo)
        {
            if (facilNo is null)
            {
                return await _context.UserRoles.Where(r => r.UserID == userID).OrderBy(o => o.FacilNo).Select(s => s.Role ?? string.Empty).FirstOrDefaultAsync();
            }

            return await _context.UserRoles.Where(r => r.UserID.ToUpper() == userID.ToUpper() && r.FacilNo == facilNo).Select(s => s.Role ?? string.Empty).FirstOrDefaultAsync();
        }

        public bool IsInRole(string userID, string role, int? facilNo)
        {
            // Await the GetRole method to resolve the Task<string?> to a string
            string? _role = this.GetRole(userID.ToUpper(), facilNo).Result;

            if (_role is null)
            {
                return false;
            }

            return _role.Equals(role, StringComparison.OrdinalIgnoreCase);
        }
    }
}
