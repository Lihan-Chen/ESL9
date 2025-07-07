using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Mvc.ViewModels
{
    public partial record _LogFilterPartialViewModel
    {

        [Required]
        [Display(Name = "Facility")]
        public int? SelectedFacilNo { get; set; }

        [Display(Name = "Log Type")]
        public int? SelectedLogTypeNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; } //= DateTime.Now.AddDays(-1);

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; } //= DateTime.Now.AddDays(1);

        [Display(Name = "Primary Operator?")]
        public bool OperatorType { get; set; }

        [Display(Name = "Keyword")]
        [RegularExpression("([a-zA-Z0-9_]+)", ErrorMessage = "Enter only alphabets and numbers of Keywords")]  //[a-zA-Z0-9_] or "\w"
        public string? CurrentFilter { get; set; }

        public SelectList facilNos { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
        public SelectList logTypeNos { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");

    }
}
