namespace Core.Models.BusinessEntities;

/// <summary>
/// This view represents the EOS Outstanding events from the VIEW_AllEvents_CURRENT view where the ModifyFlag is null and the event is not Full Released.
/// </summary>
public partial record ViewEOSOutstanding
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public int EventID_RevNo { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string FacilName { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public string? UpdateDate { get; set; }

    public string? OperatorType { get; set; }

    public int? ScanDocsNo { get; set; }
}
