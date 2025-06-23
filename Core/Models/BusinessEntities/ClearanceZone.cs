namespace Core.Models.BusinessEntities;

public partial record ClearanceZone
{
    public string FacilType { get; set; } = null!;

    public int ZoneNo { get; set; }

    public string? ZoneDescription { get; set; }

    public string? Disable { get; set; }

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? FacilNo { get; set; }
}
