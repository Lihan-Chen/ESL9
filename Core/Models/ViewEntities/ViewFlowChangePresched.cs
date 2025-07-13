namespace Core.Models.BusinessEntities;

/// <summary>
/// This view represents the pre-scheduled changes in the VIEW_ALLEVENTS_CURRENT where the ModifyFlag is null and is not a RealTime.
/// </summary>
public partial record ViewFlowChangePresched
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
