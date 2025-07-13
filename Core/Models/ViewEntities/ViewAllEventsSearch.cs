namespace Core.Models.BusinessEntities;

/// <summary>
/// This view object represents all events whose ModifyFlag are null or not in ['Deleted','Revised','Rejected']  or LIKE 'Replaced%'
/// this is the same as the ViewSearchAllEvent, consider consolidating them and using only this one in the future.
/// </summary>
public partial record ViewAllEventsSearch 
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public byte EventID_RevNo { get; set; }

    public string? OperatorType { get; set; }

    public string? ClearanceID { get; set; }
}
