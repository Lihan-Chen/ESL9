using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    /// <summary>
    /// Data Transfer Object for Search Related To functionality.
    /// Very similar to SearchDto but with different properties?
    /// </summary>
    public class Search_RelatedTo
    {
        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DisplayName("Facility")]
        public string FacilName { get; set; } = null!;

        [DisplayName("Log Type No.")]
        public int LogTypeNo { get; set; }

        [DisplayName("Log Type")]
        public string LogTypeName { get; set; } = null!;

        [DisplayName("Event")]
        public string EventID { get; set; } = null!;

        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Time")]
        public string EventTime { get; set; }

        [DisplayName("Subject")]
        public string Subject { get; set; }

        [DisplayName("Details")]
        public string Details { get; set; } = null!;

        [DisplayName("Operator Type")]
        public string OperatorType { get; set; } = null!;

        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; } = null!;

        [DisplayName("Updated On")]
        public string UpdateDate { get; set; } = null!;

        [DisplayName("ClearanceID")]
        public string ClearanceID { get; set; } = null!;
    }
}
