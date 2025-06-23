namespace Core.Models.BusinessEntities;

public partial record CalloutType
{
    public decimal CalloutTypeNo { get; set; }

    public string? CalloutTypeName { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
