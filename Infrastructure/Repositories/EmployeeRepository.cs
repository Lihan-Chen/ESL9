using Application.Interfaces.IRepositories;
using Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DataAccess.Repositories
{
    public class EmployeeRepository(EslDbContext context,
                                    ILogger<EmployeeRepository> logger
                                   ) : IEmployeeRepository  
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<EmployeeRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        #region IQueryable

        // SQL = ESL.ESL_EMPLOYEELIST_PROC
        // SQL = ESL.ESL_EMPLOYEELIST_FACIL_PROC
        // IOrderedQueryable
        public IOrderedQueryable<Employee> GetListQuery(int? facilNo)
        {
            // Consider using QueryFilter to avoid loading all records into memory
            // https://github.com/dotnet/EntityFramework.Docs/blob/live/samples/core/Querying/QueryFilters/BloggingContext.cs
            var query = _context.Employees.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            if (facilNo != null)
            {
                query = query.Where(e => e.FacilNo == facilNo);
            }
            return query.Distinct().OrderBy(o => o.LastName).ThenBy(o => o.FirstName);
        }


        // ToDo: Verify logic for external list query
        // SQL = ESL.ESL_EMPLOYEELIST_EXT_PROC WHERE GROUPNAME LIKE '%WATER SYSTEM OPERATIONS GROUP%' AND LENGTH(EMPLOYEENO) <> 4
        public IOrderedQueryable<Employee> GetListExternalQuery()
        {
            var query = _context.Employees.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            var keyWord = "%WATER SYSTEM OPERATIONS GROUP%";

            return query.Where(e => !EF.Functions.Like(e.GroupName, keyWord) && e.EmployeeNo.ToString().Length != 4).OrderBy(o => o.LastName).ThenBy(o => o.FirstName);
        }

        // SQL = SELECT * FROM ESL.ESL_EMPLOYEES WHERE EMPLOYEENO = 'employeeNo.ToString()'"
        public IQueryable<Employee> GetItemQuery(int? employeeNo)
        {
            if (employeeNo == null)
            {
                throw new ArgumentNullException(nameof(employeeNo));
            }

            return _context.Employees.AsNoTracking().Where(e => e.EmployeeNo == employeeNo);
        }

        public IQueryable<Employee> GetItemQuery(string firstName, string lastName)
        {
            int? facilNo = null!;
            return this.GetListQuery(facilNo).Where(e => e.FirstName == firstName && e.LastName == lastName);
        }

        public IQueryable<string> GetRoleByFacilityQuery(string? userID, int? facilNo)
        {
            if (userID == null || facilNo == null)
            {
                return null!;
            }

            return _context.Database.SqlQuery<string>($"SELECT ROLE FROM ESL.ESL_ALLSCADAUSERS_ROLE WHERE UPPER(USERID) = UPPER('{userID}') AND FACILNO = {facilNo}").AsNoTracking(); //.FirstOrDefault())
        }

        public async Task<int> Update(Employee employee)
        {
            //Sample SQL command text
            //var commandText = "UPDATE Categories SET IsActiveStatus = ExpirationYear < 2019 WHERE a == b";
            //var name = new SqlParameter("@employeeNo", "5");
            //_context.Database.ExecuteSqlAsync(commandText, name, cancellationToken=default ); /*<params SqlParameter[]>*/

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.EmployeeNo))
                {
                    return 0; // NotFound();
                }
                else
                {
                    throw;
                }
            }

            return employee.EmployeeNo; // NoContent();
        }

        #endregion IQueryable

        public bool EmployeeExists(string employeeFullName)
        {
            if (string.IsNullOrEmpty(employeeFullName) || !employeeFullName.Contains(','))
            {
                return false;
            }
            
            string[] names = employeeFullName.Split(',');
            
            if (names.Length < 2)
            {
                return false;
            }

            string firstName = names[1].Trim();
            string lastName = names[0].Trim();

            return _context.Employees.AsNoTracking().Any(e => e.FirstName!.ToUpperInvariant() == firstName.ToUpper(System.Globalization.CultureInfo.CurrentCulture) && 
                                                              e.LastName!.ToUpperInvariant() == lastName.ToUpper(System.Globalization.CultureInfo.CurrentCulture));
        }

        public bool EmployeeExists(int employeeNo)
        {
            return _context.Employees.AsNoTracking().Any(e => e.EmployeeNo == employeeNo);
        }

        public int ConvertToEmployeeNo(string userID)
        {
            return userID[0] == '\0' ? Convert.ToInt32(userID[2..]) : Convert.ToInt32(userID[1..]);
        }

        public string ConvertToUserID(int employeeNo)
        {
            return employeeNo.ToString().Length == 4 ? $"U0{employeeNo}" : $"U{employeeNo}";
        }

        #region Old Codes

        //public async Task<Employee?> GetEmployee(int employeeNo)
        //{
        //    var employee = await _employees.FindAsync(employeeNo);

        //    if (employee == null)
        //    {
        //        throw new Exception();  // new StreetwoodException(ErrorCode.GenericNotExist(typeof(T)));
        //    }

        //    return employee;
        //}

        //public override async Task<IEnumerable<Employee>> GetAll()
        //{
        //    try
        //    {
        //        return await _employees.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} GetAllAsync Method error", typeof(EmployeeRepository));

        //        // null
        //        return new List<Employee>();
        //    }
        //}

        //public override async Task Upsert(Employee entity)
        //{
        //    try
        //    {
        //        var existingEmployee = await _employees.FindAsync(entity.EmployeeNo); //Where(x => x.EmployeeNo == entity.EmployeeNo).FirstOrDefaultAsync();

        //        if (existingEmployee == null)
        //            await _employees.AddAsync(entity); // cancellationToken);

        //        //existingEmployee.FirstName = entity.FirstName;
        //        //existingEmployee.LastName = entity.LastName;
        //        //existingEmployee.FacilNo = entity.FacilNo;
        //        _employees.Update(entity);
        //        //_context.Entry<T>(entity).CurrentValues.SetValues(entity);              
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} UpsertAsync Method error", typeof(EmployeeRepository));
        //    }
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return false;
        //        }

        //        var emp = await _employees.FindAsync(id);

        //        _employees.Remove(emp!);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(EmployeeRepository));
        //        return false;
        //    }
        //}

        //public async Task<Employee?> GetEmployee(string firstName, string lastName)
        //{
        //    Employee? employee = await _employees.Where(e => e.FirstName.ToUpper() == firstName.ToUpper() && e.LastName.ToUpper() == lastName.ToUpper()).FirstOrDefaultAsync();

        //    //Employee? employee = await dbSet.FirstOrDefaultAsync(e => e.FirstName == firstName && e.LastName == lastName);

        //    if (employee == null)
        //    {
        //        throw new Exception();
        //    }

        //    return employee;
        //}

        #endregion Old Codes
    }
}
