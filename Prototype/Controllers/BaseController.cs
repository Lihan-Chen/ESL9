using Microsoft.AspNetCore.Mvc;
using Prototype.Models;
using System.Numerics;
using System.Security.Claims;

namespace Prototype.Controllers
{
    public class BaseController : Controller
    {
        
        protected ISession Session => HttpContext.Session;

        public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;
       
        public string UserName => IsAuthenticated ? User.Identity?.Name ?? "Unknown" : string.Empty;

        public string? UserID => IsAuthenticated ? User.Claims?.FirstOrDefault(c => c.Type == "userid")?.Value : null;

        // Role is dependent on Selected FacilNo, when FacilNo is changed, Role claim should beupdated for the ClaimsPrincipal
        public string? Role => IsAuthenticated ? User.Claims?.FirstOrDefault(c => c.Type == "role")?.Value : null;

        // DefaultFacilNo is the user's default facility number from their claims
        public int? FacilNo
        {
            get
            {
                if (IsAuthenticated)
                {
                    var facilNoClaim = User.Claims?.FirstOrDefault(c => c.Type == "DefaultFacilNo")?.Value;
                    if (int.TryParse(facilNoClaim, out int facilNo))
                    {
                        return facilNo;
                    }
                }
                return null;
            }
        }

        // IsPrimaryOperator is session based, set when user checks in
        public bool? IsPrimaryOperator
        {
            get
            {
                if (IsAuthenticated)
                {
                    if (Session.TryGetValue("IsPrimaryOperator", out var value))
                    {
                        var isPrimaryOperatorClaim = System.Text.Encoding.UTF8.GetString(value);
                        if (bool.TryParse(isPrimaryOperatorClaim, out bool isPrimaryOperatorFromSession))
                        {
                            return isPrimaryOperatorFromSession;
                        }
                    }
                    //var primaryOperatorClaim = User.Claims?.FirstOrDefault(c => c.Type == "PrimaryOperator")?.Value;
                    //if (bool.TryParse(primaryOperatorClaim, out bool isPrimaryOperator))
                    //{
                    //    return isPrimaryOperator;
                    //}
                }
                return null;
            }
        }

        // Shift is session based, set when user checks in
        public ShiftType? AssignedShift
        {
            get
            {
                if (IsAuthenticated)
                {
                    if (Session.TryGetValue("AssignedShift", out var value))
                    {
                        var shiftClaim = System.Text.Encoding.UTF8.GetString(value);
                        if (Enum.TryParse<ShiftType>(shiftClaim, out ShiftType shiftFromSession))
                        {
                            return shiftFromSession;
                        }
                    }
                }
                return null;
            }
        }

        public static IEnumerable<OperatorType> OperatorTypes => Enum.GetValues(typeof(OperatorType)).Cast<OperatorType>();

        public static IEnumerable<ShiftType> Shifts => Enum.GetValues(typeof(ShiftType)).Cast<ShiftType>();

        public async Task<List<FacilOption>> LoadFacilitiesAsync()
        {
            try
            {
                var plants = new List<Facil>
                {
                    Facil.OCC,
                    Facil.Diemer,
                    Facil.Jensen,
                    Facil.Mills,
                    Facil.Weymouth,
                    Facil.Skinner,
                    Facil.DOCC,
                    Facil.Intake,
                    Facil.Gene,
                    Facil.Iron,
                    Facil.Eagle,
                    Facil.Hinds
                };

                return plants
                    .Select(f => new FacilOption(((int)f), f.ToString()))
                    .OrderBy(f => f.FacilNo)
                    .ToList();
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Failed to load facilities, using fallback.");
                return [new FacilOption(1, "Fallback A"), new FacilOption(2, "Fallback B")];
            }
        }


        public SessionUserDto SessionUser
        {
            get
            {
                return new SessionUserDto
                {
                    UserName = UserName,
                    UserID = UserID,
                    FacilNoOnDuty = FacilNo ?? 0,
                    UserRole = Role ?? string.Empty,
                    IsPrimaryOperator = IsPrimaryOperator,
                    ShiftNoOnDuty = AssignedShift.HasValue ? (int)AssignedShift.Value : null
                };
            }
        }
    }
}
