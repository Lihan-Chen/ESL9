using System.ComponentModel.DataAnnotations;

namespace Prototype.Models
{
    public partial record SessionUserDto
    {
        public SessionUserDto() { }

        public SessionUserDto(string? v1, string? v2, int v3, string? v4, int? v5, bool? v6)
        {
            UserName = v1;
            UserID = v2;
            FacilNoOnDuty = v3;
            UserRole = v4 ?? string.Empty;
            ShiftNoOnDuty = v5;
            IsPrimaryOperator = v6;
        }

        public string? UserName { get; set; }

        public string? UserID { get; set; }

        public int FacilNoOnDuty { get; set; }

        public string? UserRole { get; set; } = null!;

        public int? ShiftNoOnDuty { get; set; }

        public bool? IsPrimaryOperator {get; set; } = null;

        public bool? IsUserCheckedIn =>
            FacilNoOnDuty > 0 && ShiftNoOnDuty.HasValue && IsPrimaryOperator.HasValue;

        // User is checked in when the authenticated has selected a plant, shift and operatory type
        // updated on the httppost action of HomeController's Login Method
        //public bool UserCheckedIn; 

        //public SessionState UserSessionState;

        //public DateTimeOffset SessionStart { get; set; } = DateTimeOffset.Now;

        //public DateTimeOffset? SessionEnd { get; set; }

        //public Guid LastSessionID { get; set; }
    }
}
