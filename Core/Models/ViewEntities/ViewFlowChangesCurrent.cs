namespace Core.Models.BusinessEntities;

/// <summary>
/// This view represents the FlowChange from ESL_FLOWCHANGES table joint with joined with logtypename, employeename, and scandocno from VIEW_FLOWCHANGE_PRESCHED (AllEvents).
/// </summary>
public partial record ViewFlowChangesCurrent
{
    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public int LogTypeNo { get; set; }

    public string LogTypeName { get; set; } = null!;

    public string EventID { get; set; } = null!;

    public int EventID_RevNo { get; set; }

    public int OperatorID { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int RequestedBy { get; set; }

    public int RequestedTo { get; set; }

    public DateTime RequestedDate { get; set; }

    public string RequestedTime { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public string EventTime { get; set; } = null!;

    public string? OffTime { get; set; }

    public string MeterID { get; set; } = null!;

    public string? ChangeBy { get; set; }

    public decimal? NewValue { get; set; }

    public string? Unit { get; set; }

    public decimal? OldValue { get; set; }

    public string? OldUnit { get; set; }

    public string? ChangeByUnit { get; set; }

    public string? Accepted { get; set; }

    public string? ModifyFlag { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Notes { get; set; }

    public string? NotifiedFacil { get; set; }

    public int? NotifiedPerson { get; set; }

    public int? ShiftNo { get; set; }

    public string Yr { get; set; } = null!;

    public int SeqNo { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public string? WorkOrders { get; set; }

    public string? RelatedTo { get; set; }

    public string? OperatorType { get; set; }
}
