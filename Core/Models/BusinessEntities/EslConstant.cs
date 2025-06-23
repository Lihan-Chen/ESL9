namespace Core.Models.BusinessEntities;

public partial record EslConstant
{
    public byte Facilno { get; set; }

    public DateTime Startdate { get; set; }

    public string Constantname { get; set; } = null!;

    public decimal? Value { get; set; }

    public DateTime? Enddate { get; set; }

    public string? Notes { get; set; }

    public string? Updatedby { get; set; }

    public DateTime? Updatedate { get; set; }
}
