namespace Core.Models.BusinessEntities;

public partial record EquipmentInvolved
{
    public int FacilNo { get; set; }

    public string FacilType { get; set; } = null!;

    public int EquipNo { get; set; }

    public string EquipName { get; set; } = null!;

    public string? Notes { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
