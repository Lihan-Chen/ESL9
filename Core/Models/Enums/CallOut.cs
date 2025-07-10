using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Enums
{
    /// <summary>
    /// Enumeration for Call-Out Types in place of ESL_CallOutType table in the database.
    /// This object does not seem to be used in current app.
    /// </summary>

    public enum CallOut
    {

        [Display(Name = "HEP Unit Trip")]
        HEPUnitTriip = 1,

        [Display(Name = "DVL Related Callout")]
        DVLRelatedCallout = 2,

        [Display(Name = "Communication Issue")]
        CommunicationIssue = 3,

        [Display(Name = "Distribution OSO")]
        DistributionOSO = 4,

        [Display(Name = "Electrical")]
        Electrical = 5,

        [Display(Name = "Meter")]
        Meter = 6,

        [Display(Name = "Water Quality")]
        WaterQuality = 7,

        [Display(Name = "Security Related")]
        SecurityRelated = 8,

        [Display(Name = "Other")]
        Other = 9,

        [Display(Name = "USA's")]
        USAs = 10
    }
}
