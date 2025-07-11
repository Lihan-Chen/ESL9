namespace Core.Models.BusinessEntities;

public partial record EslConstant
{
    public int FacilNo { get; set; }

    public DateTime StartDate { get; set; }

    public string ConstantName { get; set; } = null!;

    public decimal? Value { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
