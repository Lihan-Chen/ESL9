namespace Core.Models.BusinessEntities;

/// <summary>
/// This view represents the concatenated distinct ClearanceType from ESL_CLEARANCEISSUES with ClearnaceTypeName from ESL_CLEARANCE_TYPE.
/// Reflects only partial list from the ESL_CLEARANCE_TYPE table.
/// </summary>
public partial record ViewClearanceType
{
    public string ClearanceType { get; set; } = null!;

    public int ClearanceTypeNo { get; set; }

    public string ClearanceTypeName { get; set; } = null!;
}
