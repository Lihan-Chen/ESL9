namespace Core.Models.BusinessEntities;

public partial record ViewEOSCurrent
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

    public int? ReportedBy { get; set; }

    public int? ReportedTo { get; set; }

    public DateTime? ReportedDate { get; set; }

    public string? ReportedTime { get; set; }

    public string EquipmentInvolved { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int? ReleasedBy { get; set; }

    public DateTime? ReleasedDate { get; set; }

    public string? ReleasedTime { get; set; }

    public string? ReleaseType { get; set; }

    public string? TagsInstalled { get; set; }

    public string? TagsRemoved { get; set; }

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
