using Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    /// <summary>
    /// This represents the user session information.
    /// </summary>
    public partial record UserSessionDto
    {
        public UserSessionDto() { }

        [RegularExpression(@"'[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}")]
        public Guid SessionID { get; set; }

        public string? UserName { get; set; }

        public string? UserID { get; set; }

        // used to redirect to log in if not authenticated
        //public bool IsUserAnOperator { get; set; } = false;

        public string[] UserRole { get; set; } = null!;

        public Shift OnDutyShift { get; set; } = Shift.Day;

        public int? OnDutyShiftNo => (int)OnDutyShift;

        public string? OnDutyShiftName => OnDutyShift.ToString();

        public OperatorType OnDutyOperatorType { get; set; } = OperatorType.Primary;

        public int? OnDutyOpertorTypeNo => (int)OnDutyShift;

        public string? OnDutyOperatorTypeName => OnDutyShift.ToString();

        public int OnDutyFacilNo { get; set; }

        public string FacilName => PlantsDictionary.Plants[OnDutyFacilNo].PlantName; //.GetPlant(FacilNo).PlantName;

        // User is checked in when the authenticated has selected a plant, shift and operatory type
        // updated on the httppost action of HomeController's Login Method
        //public bool UserCheckedIn;

        public SessionState UserSessionState;

        public DateTimeOffset SessionStart { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? SessionEnd { get; set; }

        public Guid LastSessionID { get; set; }
    }
}
