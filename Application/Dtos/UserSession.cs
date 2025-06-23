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
    public partial record UserSession
    {
        public UserSession() { }

        [RegularExpression(@"'[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}")]
        public Guid SessionID { get; set; }

        public string? UserName { get; set; }

        public string? UserID { get; set; }

        // used to redirect to log in if not authenticated
        public bool IsUserAnOperator { get; set; } = false;

        public string[] UserRole { get; set; } = null!;

        public int? UserShiftNo { get; set; } //= System.Web.HttpContext.Current.Session["ShiftNo"].ToString();

        public string UserShiftName => UserShiftNo == 1 ? Shift.Day.ToString() : UserShiftNo == 2 ? Shift.Night.ToString() : string.Empty;

        public int? UserOpertorTypeNo { get; set; }

        public string? UserOperatorType => UserOpertorTypeNo == 1 ? OperatorType.Primary.ToString() : UserOpertorTypeNo == 2 ? OperatorType.Secondary.ToString() : string.Empty;

        public int UserFacilNo { get; set; }

        public string FacilName => PlantsDictionary.Plants[UserFacilNo].PlantName; //.GetPlant(FacilNo).PlantName;

        // User is checked in when the authenticated has selected a plant, shift and operatory type
        // updated on the httppost action of HomeController's Login Method
        //public bool UserCheckedIn;

        public SessionState UserSessionState;

        public DateTimeOffset SessionStart { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? SessionEnd { get; set; }

        public Guid LastSessionID { get; set; }
    }
}
