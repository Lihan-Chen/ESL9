namespace Core.Models.BusinessEntities;

public partial record RptAllEvent
{
    public string? FacilName { get; set; }

    public string? LogTypeName { get; set; }

    public string? EventID { get; set; }

    public byte? EventID_RevNo { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string? UpdatedByName { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? FacilNo { get; set; }

    public int? LogTypeNo { get; set; }
}
