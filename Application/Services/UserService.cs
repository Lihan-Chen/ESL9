using Application.Dtos;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Application.Services.UserService;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public Task<UserDto> GetUserDtoByEmployeeUserID(string? employeeUserID)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserRolesByEmployeeName(int? employeeNo)
        {
            throw new NotImplementedException();
        }

        //public class MyClaimsTransformation //: IClaimsTransformation
        //{

        /// <summary>
        /// Extension method to add a claim to the ClaimsPrincipal
        /// Only add a new claim if it does not already exist in the ClaimsPrincipal.
        /// A ClaimsIdentity is created to add the new claims and this can be added to the ClaimsPrincipal.
        /// Adopted frpm: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/claims?view=aspnetcore-9.0</summary>
        /// <param name="principal"></param>
        /// <param name="claimType"></param>
        /// <param name="claimValue"></param>
        /// <returns>Task<ClaimPrincipal></returns>

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal, string claimType, string claimValue)
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                // var claimType = "myNewClaim";
                if (!principal.HasClaim(claim => claim.Type == claimType))
                {
                    claimsIdentity.AddClaim(new Claim(claimType, claimValue));
                }

                principal.AddIdentity(claimsIdentity);
                return Task.FromResult(principal);
            }
        //}
    }
}
