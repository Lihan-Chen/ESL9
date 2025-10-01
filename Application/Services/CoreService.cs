using Application.Dtos;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CoreService(IEmployeeRepository employeeRepository, IEmpRoleRepository empRoleRepository, IFacilityRepository facilityRepository, ILogTypeRepository logTypeRepository) : ICoreService
    { 
        private readonly IEmployeeRepository _employees = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

        private readonly IEmpRoleRepository _empRoles = empRoleRepository ?? throw new ArgumentNullException(nameof(empRoleRepository));

        private readonly IFacilityRepository _facilities = facilityRepository ?? throw new ArgumentNullException(nameof(facilityRepository));
       
        private readonly ILogTypeRepository _logTypes = logTypeRepository ?? throw new ArgumentNullException(nameof(logTypeRepository));

        #region EmployeeService

        public async Task<IEnumerable<Employee>> GetActiveEmployeeListByFacilNo(int? facilNo)
        {
            return await _employees.GetListQuery(facilNo).ToListAsync();
        }

        // Check first - employeeFullName = lastName,firstName same as User.Identity.Name
        public async Task<Employee?> GetEmployeeByEmployeeName(string? employeeFullName)
        {
            Employee? _employee = null;

            // LastName,FirstName format
            if (!string.IsNullOrEmpty(employeeFullName))
            {
                string firstName = employeeFullName.Split(',')[1].Trim();
                string lastName = employeeFullName.Split(',')[0].Trim();

                _employee = await _employees.GetItemQuery(firstName, lastName).FirstOrDefaultAsync();
            }

            return _employee;
        }

        // employeeNo = 12345
        public async Task<Employee?> GetEmployeeByEmployeeNo(int employeeNo) => await _employees.GetItemQuery(employeeNo).FirstOrDefaultAsync();

        public async Task<Employee?> GetEmployeeByEmployeeID(string employeeID)
        {
            Employee? _employee = null!;

            if (!string.IsNullOrEmpty(employeeID))
            {
                // This is true only if the employeeID starts with "U0" or "U" followed by a number
                int _employeeNo = employeeID.Substring(0, 2).ToUpper() == "U0" ? int.Parse(employeeID.Substring(2)) : int.Parse(employeeID.Substring(1));

                _employee = await GetEmployeeByEmployeeNo(_employeeNo);
            }

            return _employee;
        }

        // Get FullName = lastName,firstName
        public async Task<string?> GetFullNameByEmployeeNo(int employeeNo)
        {
            Employee? _employee = await GetEmployeeByEmployeeNo(employeeNo);

            return $"{_employee?.FirstName} {_employee?.LastName}";

        }

        // Get FullName = lastName,firstName
        public async Task<string?> GetFullNameByEmployeeID(string employeeID)
        {
            Employee? _employee = await GetEmployeeByEmployeeID(employeeID);

            return $"{_employee?.FirstName} {_employee?.LastName}";
        }

        // lastName,firstName => FirstName, LastName
        public Task<string?> GetFullNameByEmployeeFullName(string? employeeFullName)
        {
            if (string.IsNullOrEmpty(employeeFullName) || !employeeFullName.Contains(','))
            {
                return Task.FromResult<string?>(null);
            }

            string? firstName = employeeFullName.Split(',')[1].Trim();
            string? lastName = employeeFullName.Split(',')[0].Trim();

            return Task.FromResult<string?>($"{firstName} {lastName}");
        }

        // Get EmployeeNo integer
        public int? GetEmployeeNoByEmployeeName(string employeeName)
        {
            int? _employeeNo = null; // Initialize the variable to avoid CS0165  

            if (!string.IsNullOrEmpty(employeeName))
            {
                Employee? _employee = GetEmployeeByEmployeeName(employeeName).Result;

                if (_employee != null)
                {
                    _employeeNo = _employee.EmployeeNo;
                }
            }

            return _employeeNo;
        }

        // Get UserID string
        public string? GetEmployeeIDByEmployeeName(string employeeName)
        {
            int? _employeeNo = GetEmployeeNoByEmployeeName(employeeName);

            if (_employeeNo == null)
            {
                return null;
            }

            return _employeeNo < 40000 ? $"U{_employeeNo?.ToString("D5")}" : $"U{_employeeNo?.ToString("D5")}";
        }

        // Get Employee's FacilityNo              
        public async Task<int?> GetEmployeeFacilNobyEmployeeName(string employeeName)
        {
            int? _facilNo = null;

            Employee? employee = await GetEmployeeByEmployeeName(employeeName);

            _facilNo = employee?.FacilNo;

            return _facilNo;
        }
        #endregion EmployeeService

        #region UserDtoService

        public async Task<UserDto> GetUserDtoByEmployeeUserID(string? employeeUserID)
        {
            if (string.IsNullOrEmpty(employeeUserID))
            {
                throw new ArgumentNullException(nameof(employeeUserID), "Employee User ID cannot be null or empty.");
            }

            var employee = GetEmployeeByEmployeeID(employeeUserID).Result;

            if (employee != null)
            {
                return new UserDto
                {
                    UserID = employeeUserID,
                    UserName = $"{employee.LastName}, {employee.FirstName}",
                    DefaultFacilNo = employee.FacilNo,
                    UserRoles = await _empRoles.GetRoles(employeeUserID)
                };
            }

            throw new InvalidOperationException($"Employee with User ID '{employeeUserID}' not found.");
        }

        public Task<Dictionary<int, string>> GetUserRolesByEmployeeNo(int? employeeNo)
        {
            if (employeeNo == null)
            {
                throw new ArgumentNullException(nameof(employeeNo), "Employee number cannot be null.");
            }

            var employee = GetEmployeeByEmployeeNo(employeeNo.Value).Result;

            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with number '{employeeNo}' not found.");
            }

            return _empRoles.GetRoles(employee.EmployeeID);
        }

        #endregion UserDtoService

        #region RoleService
        // Get Employee's role per Facility
        public async Task<UserDto?> GetUserByFullName(string? employeeFullName)
        {
            if (string.IsNullOrEmpty(employeeFullName))
            {
                return null;
            }

            Employee? employee = await GetEmployeeByEmployeeName(employeeFullName);
            if (employee == null)
            {
                return null;
            }

            string? userID = GetEmployeeIDByEmployeeName(employeeFullName);
            if (userID == null)
            {
                return null;
            }

            // not every employee record has a facilNo assigned
            int? facilNo = employee.FacilNo;

            // string? role = await GetRole(userID, facilNo);

            //Dictionary<string, Dictionary<int, string>> userRoles = await _empRoles.GetUserRoles();

            Dictionary<int, string> userRoles = await _empRoles.GetRoles(userID); // userRoles.ContainsKey(userID) ? userRoles[userID].FirstOrDefault().Value : null;

            return new UserDto
            {
                UserID = userID,
                UserName = employeeFullName, // $"{employee.FirstName} {employee.LastName}",
                DefaultFacilNo = facilNo,
                UserRoles = userRoles
            }; 
        }

        public Dictionary<string, Dictionary<int, string>> GetUserRoles()
        {
            return _empRoles.GetUserRoles();
        }

        //GetUserRoleList()
        public Dictionary<string, List<UserRole>> GetUserRoleList()
        {
            return _empRoles.GetUserRoleList();
        }

        public async Task<string?> GetRole(string userID, int? facilNo)
        {
            return await _empRoles.GetRole(userID, facilNo);
        }

        public Task<bool> IsInRole(string userID, string role, int? facilNo)
        {
            switch (role.ToUpper())
            {
                case "ESL_OPERATOR":
                    return Task.FromResult(
                        _empRoles.IsInRole(userID, role, facilNo) ||
                        _empRoles.IsInRole(userID, "ESL_ADMIN", facilNo) ||
                        _empRoles.IsInRole(userID, "ESL_SUPERADMIN", facilNo)
                    );

                case "ESL_ADMIN":
                    return Task.FromResult(
                        _empRoles.IsInRole(userID, role, facilNo) ||
                        _empRoles.IsInRole(userID, "ESL_SUPERADMIN", facilNo)
                    );

                case "ESL_SUPERADMIN":
                    return Task.FromResult(
                        _empRoles.IsInRole(userID, role, facilNo)
                    );

                default:
                    return Task.FromResult(false);
            }
        }

        // Check if the user has any roles assigned
        public Task<bool> HasAnyRoles(string userID) => _empRoles.HasAnyRole(userID);

        #endregion RoleService

        #region FacilityService
        // Facilities and Plants

        // ConfigureAwait(false) allows the continuation to run on a different thread, which can improve performance and avoid deadlocks in certain scenarios
        // https://github.com/PiranhaCMS/piranha.core/tree/master
        public async Task<IEnumerable<Facility>> GetAllPlants() => await _facilities.GetAll().ToListAsync(); //.AsAsyncEnumerable();

        public async Task<Facility?> GetFacility(int? facilNo) => await _facilities.GetFacility((int)facilNo!).FirstOrDefaultAsync();

        // For Selecting a plant (OCC, DOCC, pumping, treatment, DVL)
        public async Task<List<string>> GetFacilTypeList() => await _facilities.GetFacilTypeList().ToListAsync();

        public async Task<List<FacilDto>> GetFacilList() => await _facilities.GetFacilList().ToListAsync();

        //public async Task<SelectList> GetFacilSelectList(int? facilNo) // => new SelectList(await _facilities.GetFacilList(), "FacilNo", "FacilAbbr", facilNo);
        //{
        //    var _facilList = await _facilities.GetFacilList().ToListAsync();
        //    return new SelectList(_facilList.Select(x => new { value = x.FacilNo, text = x.FacilName.Split(' ').ElementAt(0) }), "FacilNo", "FacilName", facilNo);
        //}

        //public async Task<SelectList> GetFacilTypeSelectList() => new SelectList(await _facilities.GetFacilTypeList().ToListAsync(), "FacilType", "FacilType");

        #endregion FacilityService

        #region LogTypeService

        public async Task<List<string>> GetLogTypeList() => await _logTypes.GetLogTypeList().ToListAsync();

        public Task<LogType?> GetLogType(int logTypeNo) => _logTypes.GetLogType(logTypeNo).SingleOrDefaultAsync();

        #endregion LogTypeService


        public Task<UserSessionDto?> GetPriorUserSessionByUserName(string userName)
        {
            //throw new NotImplementedException();

            return Task.FromResult<UserSessionDto?>(null);
        }

        public Task<UserSessionDto> GetUserSession()
        {
            throw new NotImplementedException();

            //return Task.FromResult(new UserSession
            //{
            //    SessionID = Guid.NewGuid(),
            //    UserName = "DefaultUser",
            //    CreatedAt = DateTime.UtcNow,
            //    IsActive = true
            //});
        }

        public async Task<Guid> SaveUserSession(UserSessionDto userSession)
        {
            // GetPriorUserSessionByUserName() logic might be implemented here in the future.

            return await Task.FromResult(userSession.SessionID);
        }
    }
}
