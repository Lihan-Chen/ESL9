using Application.Dtos;
using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreController(ICoreService coreService) : ControllerBase
    {
        private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        // GET: api/Core/Plants
        [HttpGet("Plants")]
        public async Task<ActionResult<IEnumerable<FacilDto>>> GetPlants()
        {
            try
            {
                var plants = await _coreService.GetFacilList();
                return Ok(plants);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving plants: {ex.Message}");
            }
        }

        // GET: api/Core/LogTypes
        [HttpGet("LogTypes")]
        public async Task<ActionResult<IEnumerable<string>>> GetLogTypes()
        {
            try
            {
                var logTypes = await _coreService.GetLogTypeList();
                return Ok(logTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving log types: {ex.Message}");
            }
        }

        // GET: api/Core/Facilities
        [HttpGet("Facilities")]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities()
        {
            try
            {
                var facilities = await _coreService.GetAllPlants();
                return Ok(facilities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving facilities: {ex.Message}");
            }
        }

        // GET: api/Core/Employee/{employeeName}
        [HttpGet("Employee/{employeeName}")]
        public async Task<ActionResult<Employee?>> GetEmployeeByName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                return BadRequest("Employee name cannot be null or empty.");
            }
            try
            {
                var employee = await _coreService.GetEmployeeByEmployeeName(employeeName);
                if (employee == null)
                {
                    return NotFound($"Employee with name '{employeeName}' not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving employee: {ex.Message}");
            }
        }

        // GET: api/Core/EmployeeNo/{employeeNo}
        [HttpGet("EmployeeNo/{employeeNo}")]
        public async Task<ActionResult<Employee?>> GetEmployeeByNo(int employeeNo)
        {
            if (employeeNo <= 0)
            {
                return BadRequest("Employee number must be a positive integer.");
            }
            try
            {
                var employee = await _coreService.GetEmployeeByEmployeeNo(employeeNo);
                if (employee == null)
                {
                    return NotFound($"Employee with number '{employeeNo}' not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving employee: {ex.Message}");
            }
        }

        // GET: api/Core/EmployeeID/{employeeID}
        [HttpGet("EmployeeID/{employeeID}")]
        public async Task<ActionResult<Employee?>> GetEmployeeByID(string employeeID)
        {
            if (string.IsNullOrWhiteSpace(employeeID))
            {
                return BadRequest("Employee ID cannot be null or empty.");
            }
            try
            {
                var employee = await _coreService.GetEmployeeByEmployeeID(employeeID);
                if (employee == null)
                {
                    return NotFound($"Employee with ID '{employeeID}' not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving employee: {ex.Message}");
            }
        }

        // GET: api/Core/FullName/{employeeNo}
        [HttpGet("FullName/{employeeNo}")]
        public async Task<ActionResult<string?>> GetFullNameByEmployeeNo(int employeeNo)
        {
            if (employeeNo <= 0)
            {
                return BadRequest("Employee number must be a positive integer.");
            }
            try
            {
                var fullName = await _coreService.GetFullNameByEmployeeNo(employeeNo);
                if (fullName == null)
                {
                    return NotFound($"Full name for employee number '{employeeNo}' not found.");
                }
                return Ok(fullName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving full name: {ex.Message}");
            }
        }

        // GET: api/Core/FullNameByID/{employeeID}
        [HttpGet("FullNameByID/{employeeID}")]
        public async Task<ActionResult<string?>> GetFullNameByEmployeeID(string employeeID)
        {
            if (string.IsNullOrWhiteSpace(employeeID))
            {
                return BadRequest("Employee ID cannot be null or empty.");
            }
            try
            {
                var fullName = await _coreService.GetFullNameByEmployeeID(employeeID);
                if (fullName == null)
                {
                    return NotFound($"Full name for employee ID '{employeeID}' not found.");
                }
                return Ok(fullName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving full name: {ex.Message}");
            }
        }

        // GET: api/Core/FullNameByFullName/{employeeFullName}
        [HttpGet("FullNameByFullName/{employeeFullName}")]
        public async Task<ActionResult<string?>> GetFullNameByEmployeeFullName(string employeeFullName)
        {
            if (string.IsNullOrWhiteSpace(employeeFullName))
            {
                return BadRequest("Employee full name cannot be null or empty.");
            }
            try
            {
                var fullName = await _coreService.GetFullNameByEmployeeFullName(employeeFullName);
                if (fullName == null)
                {
                    return NotFound($"Full name for '{employeeFullName}' not found.");
                }
                return Ok(fullName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving full name: {ex.Message}");
            }
        }

        // Replace the following method in CoreController

        // GET: api/Core/Role
        [HttpGet("GetUserDomainByUserID{userID}")]
        public async Task<ActionResult<string>> GetUserDomain(string userID)
        {
            if (string.IsNullOrWhiteSpace(userID))
            {
                return BadRequest("User ID cannot be null or empty.");
            }
            try
            {
                // Use Task.Run to make the method truly asynchronous and resolve CS1998 if using GetUserRoles dictionary with Key = userID.ToUpper()
                var hasAnyRoles = await _coreService.HasAnyRoles(userID.ToUpperInvariant()); // await Task.Run(() => _coreService.GetUserRoles().ContainsKey(userID.ToUpper()));
                
                if (!hasAnyRoles)
                {
                    return Ok("Public"); // User has no roles, return "Public"
                }

                return Ok("Private"); // Roles exist, but not returning specific domain here because role should be matched by facility and userID. (value object)
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving user domain: {ex.Message}");
            }
        }

        [HttpGet("Role")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult<Dictionary<string, Dictionary<int, string>>> GetUserRoles()
        {
            try
            {
                var userRoles = _coreService.GetUserRoles();
                return Ok(userRoles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving user roles: {ex.Message}");
            }
        }

        // GET: api/Core/RoleList
        [HttpGet("RoleList")]
        public ActionResult<Dictionary<string, List<UserRole>>> GetRoleList()
        {
            try
            {
                var roles = _coreService.GetUserRoleList();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving role list: {ex.Message}");
            }
        }

        // GET: api/Core/Role/{userID}/{facilNo}
        [HttpGet("Role/{userID}/{facilNo}")]
        public async Task<ActionResult<string?>> GetRole(string userID, int? facilNo)
        {
            if (string.IsNullOrWhiteSpace(userID) || facilNo == null)
            {
                return BadRequest("User ID and Facility Number cannot be null or empty.");
            }
            try
            {
                var role = await _coreService.GetRole(userID.ToUpperInvariant(), facilNo);
                if (role == null)
                {
                    return NotFound($"Role for user '{userID}' in facility '{facilNo}' not found.");
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving role: {ex.Message}");
            }
        }

        // GET: api/Core/IsInRole/{userID}/{role}/{facilNo}
        [HttpGet("IsInRole/{userID}/{role}/{facilNo}")]
        public async Task<ActionResult<bool>> IsInRole(string userID, string role, int? facilNo)
        {
            if (string.IsNullOrWhiteSpace(userID) || string.IsNullOrWhiteSpace(role) || facilNo == null)
            {
                return BadRequest("User ID, Role, and Facility Number cannot be null or empty.");
            }
            try
            {
                var isInRole = await _coreService.IsInRole(userID.ToUpper(), role.ToUpper(), facilNo);
                return Ok(isInRole);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error checking role: {ex.Message}");
            }
        }

        // GET: api/Core/EmployeeNoByName/{employeeName}
        [HttpGet("EmployeeNoByName/{employeeName}")]
        public ActionResult<int?> GetEmployeeNoByEmployeeName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                return BadRequest("Employee name cannot be null or empty.");
            }
            try
            {
                var employeeNo = _coreService.GetEmployeeNoByEmployeeName(employeeName);
                return Ok(employeeNo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving employee number: {ex.Message}");
            }
        }

        // GET: api/Core/EmployeeIDByName/{employeeName}
        [HttpGet("EmployeeIDByName/{employeeName}")]
        public ActionResult<string?> GetEmployeeIDByEmployeeName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                return BadRequest("Employee name cannot be null or empty.");
            }
            try
            {
                var employeeID = _coreService.GetEmployeeIDByEmployeeName(employeeName);
                return Ok(employeeID);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving employee ID: {ex.Message}");
            }
        }

        // GET: api/Core/EmployeeFacilNoByName/{employeeName}
        [HttpGet("EmployeeFacilNoByName/{employeeName}")]
        public async Task<ActionResult<int?>> GetEmployeeFacilNoByEmployeeName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                return BadRequest("Employee name cannot be null or empty.");
            }
            try
            {
                var facilNo = await _coreService.GetEmployeeFacilNobyEmployeeName(employeeName);
                return Ok(facilNo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving facility number: {ex.Message}");
            }
        }

        // GET: api/Core/Facility/{facilNo}
        [HttpGet("Facility/{facilNo}")]
        public async Task<ActionResult<Facility?>> GetFacility(int? facilNo)
        {
            if (facilNo == null || facilNo <= 0)
            {
                return BadRequest("Facility number must be a positive integer.");
            }
            try
            {
                var facility = await _coreService.GetFacility(facilNo);
                if (facility == null)
                {
                    return NotFound($"Facility with number '{facilNo}' not found.");
                }
                return Ok(facility);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving facility: {ex.Message}");
            }
        }

        // GET: api/Core/FacilityTypes
        [HttpGet("FacilityTypes")]
        public async Task<ActionResult<List<string>>> GetFacilityTypes()
        {
            try
            {
                var facilityTypes = await _coreService.GetFacilTypeList();
                return Ok(facilityTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving facility types: {ex.Message}");
            }
        }

        //// GET: api/Core/EmployeeList
        //[HttpGet("EmployeeList")]
        //public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeList(int? facilNo)
        //{
        //    try
        //    {
        //        var employees = await _coreService.GetListQuery(facilNo).ToListAsync();
        //        return Ok(employees);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving employee list: {ex.Message}");
        //    }
        //}
    }
}
