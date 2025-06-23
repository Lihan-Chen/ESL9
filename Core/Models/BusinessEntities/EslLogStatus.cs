namespace Core.Models.BusinessEntities;

public partial record EslLogStatus
{
    public decimal LogStatusNo { get; set; }

    public string LogStatusDescription { get; set; } = null!;

    public string? Notes { get; set; }
}
