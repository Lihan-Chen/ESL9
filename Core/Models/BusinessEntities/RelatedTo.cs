namespace Core.Models.BusinessEntities;

public partial record RelatedTo
{
    public int FacilNo { get; set; }

    public int LogTypeNo { get; set; }

    public string EventID { get; set; } = null!;

    public string RelatedToSubject { get; set; } = null!;

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
