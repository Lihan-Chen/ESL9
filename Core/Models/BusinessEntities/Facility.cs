namespace Core.Models.BusinessEntities;

public partial record Facility
{
    #region POCO Properties

    public int FacilNo { get; set; }

    public string FacilName { get; set; } = null!;

    public string FacilAbbr { get; set; } = null!;

    public string FacilType { get; set; } = null!;

    public int? SortNo { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Disable { get; set; }

    public string? VisibleTo { get; set; }

    public string? FacilFullName { get; set; }

    #endregion POCO Properties
}
