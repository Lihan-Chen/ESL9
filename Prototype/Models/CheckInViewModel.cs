namespace Prototype.Models
{
    public record CheckInViewModel
    {
        public int? FacilNo { get; set; } // Facility No
        public string? FacilName { get; set; } // Facility Name
        public int? ShiftNo { get; set; } // Shift No
        public string? ShiftName { get; set; } // Shift Name
        public int? OperatorTypeNo { get; set; } // Operator Type No
        public string? OperatorTypeName { get; set; } // Operator Type Name
        public bool IsUserAnOperator { get; set; } = false;
    }
}
