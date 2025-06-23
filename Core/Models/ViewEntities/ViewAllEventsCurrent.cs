namespace Core.Models.BusinessEntities;

public partial record ViewAllEventsCurrent
{
    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;

    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string EventID { get; set; } = null!;

    public int EventID_RevNo { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string? ModifyFlag { get; set; }

    public string? Notes { get; set; }

    public string? OperatorType { get; set; }

    public string? UpdatedBy { get; set; }

    public string? UpdateDate { get; set; }

    public string? ClearanceID { get; set; }

    public decimal? ScanDocsNo { get; set; }
}
