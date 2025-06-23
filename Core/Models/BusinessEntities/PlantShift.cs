namespace Core.Models.BusinessEntities;

public partial record PlantShift
{
    public int FacilNo { get; set; }

    public int ShiftNo { get; set; }

    public string? ShiftName { get; set; }

    public string ShiftStart { get; set; } = null!;

    public string ShiftEnd { get; set; } = null!;

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
