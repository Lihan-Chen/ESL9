// ESL9.Mvc/Models/PlantSelectViewModel.cs
using System.ComponentModel.DataAnnotations;

public class FacilSelectViewModel
{
    [Required]
    [Display(Name = "Facility")]
    public int FacilNo { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string FacilName { get; set; } = string.Empty;

    public bool IsSelected { get; set; }
}
