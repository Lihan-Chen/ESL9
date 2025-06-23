namespace Core.Models.BusinessEntities;

public partial record WorkToBePerformed
{
    public string FacilType { get; set; } = null!;

    public int WorkNo { get; set; }

    public string WorkDescription { get; set; } = null!;

    public string? Notes { get; set; }

    public int? SortNo { get; set; }

    public string? Disable { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
