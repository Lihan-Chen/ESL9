using Core.Models.BusinessEntities;
using System.ComponentModel;

namespace Application.Dtos
{
    /// <summary>
    /// This corresponds to ViewAllEventsFacilNo (VIEW_ALLEVENTS_FACILNOS) view in the database.
    /// </summary>
    public partial record FacilDto : ViewAllEventsFacilNo
    {
        //#region Public Properties

        //[DisplayName("Facility No.")]
        //public int FacilNo { get; set; }

        //[DisplayName("Facility")]
        //public string FacilName { get; set; } = null!;

        //[DisplayName("Abreviation")]
        //public string FacilAbbr { get; set; } = null!;

        //#endregion
    }
}
