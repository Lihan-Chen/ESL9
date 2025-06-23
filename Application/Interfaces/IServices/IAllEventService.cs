using Core.Models.BusinessEntities;

namespace Application.Interfaces.IServices
{
    public interface IAllEventService
    {
        // Get AllEventsCurrent by LogFilterPartialModel and facilNo, etc.
        public Task<Employee?> GetEmployeeByEmployeeName(string employeeName);

        public Task<Employee?> GetEmployeeByEmployeeNo(int employeeNo);

        public Task<Employee?> GetEmployeeByEmployeeID(string employeeID);

        // Get FullName
        public Task<string?> GetFullNameByEmployeeNo(int employeeNo);

        public Task<string?> GetFullNameByEmployeeID(string EmployeeID);

        // Get EmployeeID integer
        public Task<int?> GetEmployeeNoByEmployeeName(string employeeName);

        // Get UserID string
        public Task<string?> GetEmployeeIDByEmployeeName(string employeeName);

        // Get Employee's FacilityNo              
        public Task<int?> GetEmployeeFacilNobyEmployeeName(string employeeName);

        public Task<string?> GetRole(string userID, int facilNo);
        public Task<bool> IsInRole(string userID, string role, int facilNo);
    }
}
