using System.ComponentModel;

namespace Application.Dtos
{
    public partial record LogFilterPartialDto
    {
        [DisplayName("Facility")]
        public int? FacilNo { get; set; }

        [DisplayName("Log Type")]
        public int? LogTypeNo { get; set; }


        [DisplayName("Start Date")] 
        public DateOnly? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateOnly? EndDate { get; set; }

        [DisplayName("Keywords")]
        public string? SearchString { get; set; }

        [DisplayName("Primary Operator")] 
        public bool? IsPrimaryOperator { get; set; }
    }
}
