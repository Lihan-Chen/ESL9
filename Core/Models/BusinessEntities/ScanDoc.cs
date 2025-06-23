namespace Core.Models.BusinessEntities;

public partial record ScanDoc
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public int ScanNo { get; set; }

    public string ScanFileName { get; set; } = null!;

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
