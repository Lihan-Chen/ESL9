namespace Core.Models.BusinessEntities;

public partial record ViewAllEventsFacilNo
{
    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;
}
