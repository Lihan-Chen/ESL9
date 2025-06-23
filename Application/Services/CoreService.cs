using Application.Dtos;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CoreService : ICoreService
    {
        private readonly IEmployeeRepository _employees;

        private readonly IFacilityRepository _facilities;

        private readonly IEmpRoleRepository _empRoles;

        private readonly ILogTypeRepository _logTypes;

        public CoreService(IEmployeeRepository employeeRepository, IFacilityRepository facilityRepository, IEmpRoleRepository empRoleRepository, ILogTypeRepository logTypeRepository)
        {
            _employees = employeeRepository;
            _facilities = facilityRepository;
            _empRoles = empRoleRepository;
            _logTypes = logTypeRepository;
        }

        #region EmployeeService
        // Check first - employeeFullName = lastName,firstName same as User.Identity.Name
        public async Task<Employee?> GetEmployeeByEmployeeName(string? employeeFullName)
        {
            Employee? _employee = null;

            // LastName,FirstName format
            if (!string.IsNullOrEmpty(employeeFullName))
            {
                string firstName = employeeFullName.Split(',')[1];
                string lastName = employeeFullName.Split(',')[0];

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

        // Get FullName = lastName,firstName
        public Task<string?> GetFullNameByEmployeeFullName(string? employeeFullName)
        {
            if (string.IsNullOrEmpty(employeeFullName) || !employeeFullName.Contains(','))
            {
                return Task.FromResult<string?>(null);
            }

            string? firstName = employeeFullName.Split(',')[1];
            string? lastName = employeeFullName.Split(',')[0];

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

            return _employeeNo < 10000 ? $"U{_employeeNo?.ToString("D4")}" : $"U{_employeeNo?.ToString("D5")}";
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

        #region RoleService
        // Get Employee's role per Facility
        public async Task<string?> GetRole(string userID, int? facilNo)
        {
            return await _empRoles.GetRole(userID, facilNo);
        }

        public Task<bool> IsInRole(string userID, string role, int? facilNo)
        {
            switch (role)
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

        #endregion RoleService

        #region FacilityService
        // Facilities and Plants

        // ConfigureAwait(false) allows the continuation to run on a different thread, which can improve performance and avoid deadlocks in certain scenarios
        // https://github.com/PiranhaCMS/piranha.core/tree/master
        public Task<IEnumerable<Facility>> GetAllPlants() => (Task<IEnumerable<Facility>>)_facilities.GetAll().AsAsyncEnumerable();

        public Task<Facility?> GetFacility(int? facilNo) => _facilities.GetFacility((int)facilNo!).FirstOrDefaultAsync();

        // For Selecting a plant (OCC, DOCC, pumping, treatment, DVL)
        public Task<List<string>> GetFacilTypeList() => _facilities.GetFacilTypeList().ToListAsync();

        public Task<List<FacilDto>> GetFaciList() => _facilities.GetFacilList().ToListAsync();

        //public async Task<SelectList> GetFacilSelectList(int? facilNo) // => new SelectList(await _facilities.GetFacilList(), "FacilNo", "FacilAbbr", facilNo);
        //{
        //    var _facilList = await _facilities.GetFacilList().ToListAsync();
        //    return new SelectList(_facilList.Select(x => new { value = x.FacilNo, text = x.FacilName.Split(' ').ElementAt(0) }), "FacilNo", "FacilName", facilNo);
        //}

        //public async Task<SelectList> GetFacilTypeSelectList() => new SelectList(await _facilities.GetFacilTypeList().ToListAsync(), "FacilType", "FacilType");

        #endregion FacilityService

        #region LogTypeService

        public async Task<List<string>> GetLogTypeList() => await _logTypes.GetLogTypeList().ToListAsync();

        #endregion LogTypeService


        public Task<UserSession?> GetPriorUserSessionByUserName(string userName)
        {
            //throw new NotImplementedException();

            return Task.FromResult<UserSession?>(null);
        }

        public Task<UserSession> GetUserSession()
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

        public async Task<Guid> SaveUserSession(UserSession userSession)
        {
            // GetPriorUserSessionByUserName() logic might be implemented here in the future.

            return await Task.FromResult(userSession.SessionID);
        }
    }
}
