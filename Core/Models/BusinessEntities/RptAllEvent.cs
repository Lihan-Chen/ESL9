namespace Core.Models.BusinessEntities;

/// <summary>
/// The RptAllEvent class represents an event for a type of log that belongs to a <see cref="AllEvent"> AllEvent</see>.
/// Corresponds to the Rpt or Report class in mvc4ESL, ESL_RPT_AllEVENTS table in the database.
/// </summary>
public partial record RptAllEvent
{
    public string? FacilName { get; set; }

    public string? LogTypeName { get; set; }

    public string? EventID { get; set; }

    public int? EventID_RevNo { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventTime { get; set; }

    public string? Subject { get; set; }

    public string? Details { get; set; }

    public string? UpdatedByName { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? FacilNo { get; set; }

    public int? LogTypeNo { get; set; }
}
