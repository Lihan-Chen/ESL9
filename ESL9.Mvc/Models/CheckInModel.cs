using Core.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class CheckInModel
    {
        [Display(Name = "User ID")]
        public required string UserID { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        [Display(Name = "Facility")]
        public required Facil FacilNo { get; set; }

        [Display(Name = "Primary Operator?")]
        public required bool IsPrimaryOperator { get; set; }

        [Display(Name = "Shift: Day/Night")]
        public required Shift Shft { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        // Fix CS0234: Use System.Enum.GetValues instead of Enum.facil.GetValues
        public IEnumerable<FacilSelectViewModel> FacilOptions { get; set; } = System.Enum.GetValues(typeof(Facil))
            .Cast<Facil>()
            .Select(p => new FacilSelectViewModel
            {
                FacilNo = (int)p,
                FacilName = FacilExtensions.GetFacilName(p)
            })
            .ToList();

        public IEnumerable<SelectListItem> ShiftOption { get; set; } = new List<SelectListItem>
                    {
                        new SelectListItem { Value = "1", Text = "Day" },
                        new SelectListItem { Value = "2", Text = "Night" }
                    };
    }
}
