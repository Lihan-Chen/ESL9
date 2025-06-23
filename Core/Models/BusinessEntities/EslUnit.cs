namespace Core.Models.BusinessEntities;

public partial record EslUnit
{
    public decimal UnitNo { get; set; }

    public string? UnitName { get; set; }

    public string? UnitDesc { get; set; }

    public string? Notes { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
