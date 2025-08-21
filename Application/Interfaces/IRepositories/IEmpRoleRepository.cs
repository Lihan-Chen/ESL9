using Core.Models.BusinessEntities;

namespace Application.Interfaces.IRepositories
{
    public interface IEmpRoleRepository
    {
        public Dictionary<string, Dictionary<int, string>> GetUserRoles();

        public Dictionary<string, List<UserRole>> GetUserRoleList(); 

        public Task<Dictionary<int, string>> GetRoles(string userID);

        public Task<string?> GetRole(string userID, int? facilNo);

        public bool IsInRole(string userID, string role, int? facilNo);

        public Task<bool> HasAnyRole(string userID);
    }
}
