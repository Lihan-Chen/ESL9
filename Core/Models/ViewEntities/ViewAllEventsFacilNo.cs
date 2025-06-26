namespace Core.Models.BusinessEntities;

/// <summary>
/// This represents a view of distinct facility numbers from the AllEvents table.
/// Used to retrieve a list of facilities with their names and abbreviations.
/// </summary>
public partial record ViewAllEventsFacilNo
{
    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;
}
