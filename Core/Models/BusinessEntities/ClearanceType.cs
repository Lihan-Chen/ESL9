namespace Core.Models.BusinessEntities;

public partial record ClearanceType
{
    public int ClearanceTypeNo { get; set; }

    public string ClearanceTypeName { get; set; } = null!;

    public string ClearanceTypeAbbr { get; set; } = null!;

    public int SortNo { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
