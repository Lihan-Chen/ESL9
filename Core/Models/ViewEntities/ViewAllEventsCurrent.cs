namespace Core.Models.BusinessEntities;

/// <summary>
/// A view of AllEvent, representing AllEvent from AllEvents table for all facilities where -
/// ModifyFlag is null, or not in ["Revised", "Deleted", "Rejected", "Accepte"], or not like "Replaced w/ Rev.%".
/// </summary>
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

    public int? ScanDocsNo { get; set; }
}
