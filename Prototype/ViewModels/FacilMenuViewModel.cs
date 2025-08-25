using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Prototype.ViewModels
{
    public class FacilMenuViewModel
    {
        [Required]
        [Display(Name = "User ID")]
        public string? UserID { get; set; }

        [Required]
        [Display(Name = "Facility")]
        public int FacilNo { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string FacilName { get; set; } = string.Empty;

        public bool IsSelected { get; set; }

        // should list of facilities for dropdown be included? 
        public List<SelectListItem> FacilOptions { get; set; } = new List<SelectListItem>();
    }
}
