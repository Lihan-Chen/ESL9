using System.ComponentModel;

namespace Application.Dtos
{
    public partial record FacilDto
    {
        #region Public Properties

        [DisplayName("Facility No.")]
        public int FacilNo { get; set; }

        [DisplayName("Facility")]
        public string FacilName { get; set; } = null!;

        [DisplayName("Abreviation")]
        public string FacilAbbr { get; set; } = null!;

        #endregion
    }
}
