namespace Core.Models.BusinessEntities;

/// <summary>
/// This view represents the same from ESL_WORKORDERS table.
/// Can be possibly removed in the future as it may not be needed in the application.
/// </summary>
public partial record ViewWorkOrder
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public string WoNo { get; set; } = null!;

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
