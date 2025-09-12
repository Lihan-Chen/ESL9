using Application.Dtos;
using Core.Models.BusinessEntities;

namespace Application.Interfaces.IServices
{
    public interface ICoreService
    {
        #region Employee-related Services

        // Get Employee
        public Task<IEnumerable<Employee>> GetActiveEmployeeListByFacilNo(int? facilNo);

        public Task<Employee?> GetEmployeeByEmployeeName(string? employeeName);

        public Task<Employee?> GetEmployeeByEmployeeNo(int employeeNo);

        public Task<Employee?> GetEmployeeByEmployeeID(string employeeID);

        // Get FullName
        public Task<string?> GetFullNameByEmployeeNo(int employeeNo);

        public Task<string?> GetFullNameByEmployeeID(string EmployeeID);

        public Task<string?> GetFullNameByEmployeeFullName(string? employeeFullName);

        // Get EmployeeNo integer
        public int? GetEmployeeNoByEmployeeName(string employeeName);

        // Get EmployeeID string
        public string? GetEmployeeIDByEmployeeName(string employeeName);

        // Get Employee's FacilityNo              
        public Task<int?> GetEmployeeFacilNobyEmployeeName(string employeeName);

        public Dictionary<string, Dictionary<int, string>> GetUserRoles();

        public Dictionary<string, List<UserRole>> GetUserRoleList();

        #region UserDtoService

        public Task<UserDto> GetUserDtoByEmployeeUserID(string? employeeUserID);

        public Task<Dictionary<int, string>> GetUserRolesByEmployeeNo(int? employeeNo);

        #endregion UserDtoService

        // Employee Role-related Services
        public Task<string?> GetRole(string userID, int? facilNo);

        public Task<bool> IsInRole(string userID, string role, int? facilNo);

        public Task<bool> HasAnyRoles(string userID);

        #endregion Employee-related Services

        #region Facility-related Services

        //Facilities
        public Task<IEnumerable<Facility>> GetAllPlants();

        public Task<Facility?> GetFacility(int? facilNo);

        // For Selecting a plant (OCC, DOCC, pumping, treatment, DVL)
        public Task<List<FacilDto>> GetFaciList();

        //public Task<SelectList> GetFacilSelectList(int? facilNo);

        public Task<List<string>> GetFacilTypeList();
        #endregion Facility-related Services

        #region LogType-related Services

        // LogType-related Services
        public Task<List<string>> GetLogTypeList();

        public Task<LogType?> GetLogType(int logTypeNo);

        #endregion LogType_related Services

        #region Session-related Services

        Task<UserSessionDto> GetUserSession();

        Task<UserSessionDto?> GetPriorUserSessionByUserName(string userName);

        Task<Guid> SaveUserSession(UserSessionDto userSession);

        #endregion Session-related Services

        #region Notification Services

        //Task<>

        #endregion Nofitication Services



        //public Task<SelectList> GetFacilTypeSelectList();

        //public Task<SelectList> GetLogTypeSelectList(int? logTypeNo);

        //public Task<SelectList> GetLogTypeSelectList();

        //Task<bool> IsValidUser(string userName, string password);
        //Task<bool> IsValidUser(string userName, string password, string domain);
        //Task<bool> IsValidUser(string userName, string password, string domain, string server);
        //Task<bool> IsValidUser(string userName, string password, string domain, string server, int port);
    }
}
