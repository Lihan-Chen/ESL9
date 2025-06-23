namespace Core.Models.BusinessEntities;

public partial record Employee
{
    #region POCO Properties

    public int EmployeeNo { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Company { get; set; }

    public string? GroupName { get; set; }

    public int? FacilNo { get; set; }

    public string? JobTitle { get; set; }

    public string? Notes { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Disable { get; set; }

#endregion POCO Properties

    public string EmployeeID => this.EmployeeNo.ToString().Length == 4 ? $"U0{EmployeeNo}" : $"U{EmployeeNo}";

    public int? CreatedBy { get; }
}
