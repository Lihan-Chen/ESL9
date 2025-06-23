namespace Core.Models.BusinessEntities;

public partial record RptMisc
{
    public int? FacilNo { get; set; }

    public int? ServerFacilNo { get; set; }

    public int? LogTypeNo { get; set; }

    public string? EventID { get; set; }

    public byte? EventID_RevNo { get; set; }

    public string? LogTypeSpecific { get; set; }
}
