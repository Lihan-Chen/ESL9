using Core.Models.BusinessEntities;

namespace Application.Interfaces.IRepositories
{
    public interface IEmpRoleRepository
    {
        public Task<Dictionary<string, Dictionary<int, string>>> GetUserRoles();

        public Task<Dictionary<string, List<UserRole>>> GetUserRoleList(); 

        public Task<Dictionary<int, string>> GetRoles(string userID);

        public Task<string?> GetRole(string userID, int? facilNo);

        public bool IsInRole(string userID, string role, int? facilNo);
    }
}
