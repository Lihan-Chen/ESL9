namespace Core.Models.BusinessEntities;

/// <summary>
/// This view represents ESL.VIEW_FLOWCHANGE_PRESCHED events where the event prescheduled datetime is due within 30 mins (30/1440 of a day) of current time.
/// </summary>
public partial record ViewRealTime
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public byte EventID_RevNo { get; set; }

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
