using System.ComponentModel.DataAnnotations;

namespace Mvc.Models.Constants
{
    // This file defines an enumeration for various call-out types used in the application.
    // This replaces the ESL_CallOutType table in the database.
    public enum CallOut
    {
       
        [Display(Name="HEP Unit Trip")]
        HEPUnitTriip =1,

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
