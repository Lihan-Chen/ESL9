namespace Core.Models.BusinessEntities;

public partial record ViewClearanceType
{
    public string ClearanceType { get; set; } = null!;

    public int ClearanceTypeNo { get; set; }

    public string ClearanceTypeName { get; set; } = null!;
}
