namespace Core.Models.BusinessEntities;

/// <summary>
/// This view represents the ClearanceOutstanding from AllEvents_Current wiht Clearance log type, ModifyFlag is null, and not "Full Release).
/// </summary>
public partial record ViewClearanceOutstanding
{
    public int FacilNo { get; set; }

    public string EventID { get; set; } = null!;

    public int EventID_RevNo { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public string? UpdateDate { get; set; }

    public string? OperatorType { get; set; }

    public string? ClearanceID { get; set; }

    public int? ScanDocsNo { get; set; }
}
