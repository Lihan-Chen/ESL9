using Application.Dtos;
using Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public  interface IUserService
    {
        public Task<UserDto> GetUserDtoByEmployeeUserID(string? employeeUserID);

        public Task<UserDto> GetUserRolesByEmployeeName(int? employeeNo);

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal, string claimType, string claimValue);
    }
}
