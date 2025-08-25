using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prototype.Models
{
    public record CheckInViewModel
    {
        public int? SelectedFacilNo { get; set; } // Facility No
        //public string? FacilName { get; set; } // Facility Name
        public int? SelectedShiftNo { get; set; } // Shift No
        //public string? ShiftName { get; set; } // Shift Name
        public bool IsPrimaryOperator { get; set; } // Operator Type No

        public SelectList? FacilOptions { get; set; } // Facility Options

        //public SelectList? ShiftOptions { get; set; } // Shift Options

        //public string? OperatorTypeName { get; set; } // Operator Type Name
        //public bool IsUserAnOperator { get; set; } = false;
    }
}
