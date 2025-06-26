namespace Core.Models.BusinessEntities;

/// <summary>
/// This represents a view of all events related to an event.
/// Needs to check the logic of the view in the database.
/// ModifyFlag is not in ["Deleted", "Revised", "Rejected"], or like "Replaced...", or null.
/// </summary>
public partial record ViewAllEventsRelatedTo
{
    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;

    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string EventID { get; set; } = null!;

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string? OperatorType { get; set; }

    public string? UpdatedBy { get; set; }

    public string? UpdateDate { get; set; }

    public string? ClearanceID { get; set; }
}
