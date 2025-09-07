using Core.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Mvc.ViewModels
{
    public record CheckInViewModel
    {

        [Display(Name = "Employee ID")] 
        public string? UserId { get; init; }

        [Required]
        [Display(Name = "Facility")]
        public int? SelectedFacilNo { get; init; }


        [Required]
        [Display(Name = "Shift: Day/Night")]
        public Shift Shift { get; init; }


        [Required]
        [Display(Name = "Is Primary Operator?")]
        public bool IsPrimaryOperator { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

        public string? SessionMode { get; set; } // "Private" or "Public"

        //public IEnumerable<SelectListItem> optionIsPrimary { get; set; } = [];

        public IEnumerable<SelectListItem> optionShift { get; set; } = new List<SelectListItem>
                    {
                        new SelectListItem { Value = "1", Text = "Day" },
                        new SelectListItem { Value = "2", Text = "Night" }
                    };

        public IEnumerable<SelectListItem> optionFacil { get; set; } = Enum.GetValues<Facil>()
            //.Cast<Facil>()
            .Select(p => new SelectListItem
            {
                Value = ((int)p).ToString(),
                Text = FacilExtensions.GetFacilName(p)
            })
            .ToList();

        public IEnumerable<FacilSelectViewModel> FacilOptions { get; set; } 

        public IEnumerable<SelectListItem> ShiftOption { get; set; } 
    }
}
