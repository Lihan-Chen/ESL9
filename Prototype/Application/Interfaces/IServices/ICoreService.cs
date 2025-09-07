using Prototype.Core.Models.BusinessEntities;
using Prototype.Core.Models.BusinessEntities.Enum;

namespace Prototype.Application.Interfaces.IServices
{
    public interface ICoreService
    {
        public Task<IEnumerable<Facil>> GetAllPlants();

        public Task<IEnumerable<LogType>> GetLogTypeList();

        public Task<IEnumerable<FacilType>> GetFacilTypeList();


        public Task<string> GetEmployeeFullName(string employeeId);

        public Task<string> GetRole(string employeeId, int facilityId);

        public Task<Core.Models.BusinessEntities.Employee?> GetEmployeeById(string employeeId);

        public Task<string> GetEmployeeFullName(string employeeId, string email);

        public Task<string> GetRole(string employeeId, int facilityId, string email);

        public Task<Core.Models.BusinessEntities.Employee?> GetEmployeeById(string employeeId, string email);   

        public Task<IEnumerable<Role>> GetUserRolesByEmployeeNo(int employeeNo);
        Task<string?> GetFullNameByEmployeeID(string employeeId);
        Task<Employee?> GetEmployeeByEmployeeID(string employeeId);
        Task<bool> IsInRole(string v1, string v2, int facilNo);
    }
}
