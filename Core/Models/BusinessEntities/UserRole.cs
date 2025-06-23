namespace Core.Models.BusinessEntities;

public partial record UserRole
{
    public decimal FacilNo { get; set; }  // int

    public string UserID { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? AdminOption { get; set; }

    public string? DefaultRole { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdatedBy { get; set; }
}
