using Application.Interfaces.IServices;
using Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AllEventService : IAllEventService
    {
        // Implement the methods and properties of the IAllEventService interface here
        public Task<Employee?> GetEmployeeByEmployeeID(string employeeID)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetEmployeeByEmployeeName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetEmployeeByEmployeeNo(int employeeNo)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetEmployeeFacilNobyEmployeeName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetEmployeeIDByEmployeeName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetEmployeeNoByEmployeeName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetFullNameByEmployeeID(string EmployeeID)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetFullNameByEmployeeNo(int employeeNo)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetRole(string userID, int facilNo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRole(string userID, string role, int facilNo)
        {
            throw new NotImplementedException();
        }
    }
}
