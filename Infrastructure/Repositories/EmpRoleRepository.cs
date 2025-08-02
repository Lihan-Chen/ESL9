using Application.Dtos;
using Application.Interfaces.IRepositories;
using Core.Models.BusinessEntities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public class EmpRoleRepository(EslDbContext context,
                ILogger<EmpRoleRepository> logger
                ) : IEmpRoleRepository
    {
        protected readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        protected readonly ILogger<EmpRoleRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        // ToDo: fix null content, possibly a LINQ bug
        // Dictionary of userID and keyvalue pair of facilNo and role <userID, (facilNo, role)>
        public async Task<Dictionary<string, Dictionary<int, string>>> GetUserRoles()
        {
            var userRoles = _context.UserRoles.GroupBy(u => u.UserID).ToList();

            logger.LogInformation("testing");

            var result =  _context.UserRoles.OrderBy(u => u.UserID).AsEnumerable().GroupBy(u => u.UserID).ToDictionary(group => group.Key, group => group.ToDictionary(u => (int)u.FacilNo, u => u.Role ?? string.Empty));

            //var result = await _context.UserRoles.GroupBy(u => u.UserID).ToDictionaryAsync(group => group.Key, group => group.ToDictionary(u=> (int)u.FacilNo, u => u.Role));

            // https://stackoverflow.com/questions/6361880/linq-group-by-into-a-dictionary-object
            //    var userRolesDictionary = await _context.UserRoles
            //            .GroupBy(u => u.UserID) // Group by UserID
            //            .ToDictionaryAsync(
            //                group => group.Key, // Key for the outer dictionary is UserID
            //                group => group.ToDictionary( // Select(user => new { user.FacilNo, user.Role }
            //                    u => u.FacilNo, // Key for the inner dictionary is FacilNo
            //                    u => u.Role ?? String.Empty // Value for the inner dictionary is Role
            //                )
            //);

            return result;


            // Group by UserID
            //.ToDictionaryAsync(
            //    group => group.Key,
            //    group => group.ToDictionary(
            //        user => (int)user.FacilNo, // Key for the inner dictionary is FacilNo
            //        user => user.Role ?? string.Empty // Value for the inner dictionary is Role
            //    ));
            // Key for the outer dictionary is UserID
            //    g => g.ToDictionary(
            //        u => (int)u.FacilNo, // Key for the inner dictionary is FacilNo
            //        u => u.Role ?? string.Empty // Value for the inner dictionary is Role
            //    )
            //);

        }

        public async Task<Dictionary<string, List<UserRole>>> GetUserRoleList()
        {
            return (Dictionary<string, List<UserRole>>)_context.UserRoles.OrderBy(u => u.UserID)
                //.Where(e => e.SomeCondition)
                .AsEnumerable() // Forces client-side evaluation
                .GroupBy(u => u.UserID)
                .ToDictionary(
                    group => group.Key, // The key of the dictionary will be the grouping key (e.g., RoleName)
                    group => group.ToList()); // The value will be a List of UserRole objects for that group
        }

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

        public async Task<Dictionary<int, string>> GetRoles(string userID)
        {
            return await _context.UserRoles
                .Where(r => r.UserID == userID)
                .ToDictionaryAsync(
                    r => (int)r.FacilNo, r => r.Role ?? string.Empty);

            //retrun GetUserRoles()
            //    .ContinueWith(task =>
            //    {
            //        if (task.IsCompletedSuccessfully)
            //        {
            //            var userRoles = task.Result;
            //            if (userRoles.TryGetValue(userID.ToUpper(), out var roles))
            //            {
            //                return roles;
            //            }
            //        }
            //        return new Dictionary<int, string>();
            //    });
        }
    }
}
