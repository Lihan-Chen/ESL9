using Core.Models.BusinessEntities;

namespace Application.Interfaces.IRepositories
{

    public interface IEmployeeRepository // : IGenericRepository<Employee>
    {
        #region
        /// <summary>
        /// Gets a list of Employees (per facility)
        /// Maps to string _sql = "ESL.ESL_EMPLOYEELIST_PROC";
        /// </summary>
        /// <param name="facilNo">The unique No of the Facility in the database.</param>
        /// <returns>An IQueryable of Employee for the parameters specified, or an empty list otherwise.</returns>
        public IOrderedQueryable<Employee> GetListQuery(int? facilNo);

        /// <summary>
        /// Gets a list of extermal Employees
        /// Maps to public static EmployeeList GetListByFacilNo(int facilNo)
        /// </summary>
        /// <param name="facilNo">The unique No of the Facility in the database.</param>
        /// <returns>An IQueryable of Employee list with Employee objects when the database contains Employees for the parameters specified, or an empty list otherwise.</returns>
        public IOrderedQueryable<Employee> GetListExternalQuery();

        /// <summary>
        /// Gets an Employee? from the database by its EmployeeNo.
        /// </summary>
        /// <param name="employeeNo">The unique EmployeeNo of the Employee in the database.</param>
        /// <returns>An FlowChange object when the record exists in the database, or <see langword="null"/> otherwise.</returns>
        public IQueryable<Employee> GetItemQuery(int? employeeNo);

        public IQueryable<Employee> GetItemQuery(string firstName, string lastName);

        /// <summary>
        /// Gets the role of the Employee from the database by its EmployeeNo.
        /// Maps to public static string GetRole(string userID, int facilNo)
        /// </summary>
        /// <param name="employeeNo">The unique Employee No in the database.</param>
        /// <param name="facilNo">The unique Facil No in the database.</param>
        /// <returns>A string of role when the record exists in the database, or <see langword="null"/> otherwise.</returns>
        public IQueryable<string> GetRoleByFacilityQuery(string? userID, int? facilNo);

        /// <summary>
        /// Updates an Employee record in the database.
        /// Maps to public static int Update(Employee myEmployee)
        /// </summary>
        ///<param name="employee">The Employee instance to save.</param>
        ///<returns>The new employeeNo if the FlowChange is new in the database or the existing employeeNo when an item was updated.</returns>
        public Task<int> Update(Employee employee);

        public bool EmployeeExists(string employeeFullName);

        public bool EmployeeExists(int employeeNo);

        public int ConvertToEmployeeNo(string userID);

        public string ConvertToUserID(int employeeNo);

        #endregion
    }
}

