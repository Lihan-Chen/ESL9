using Application.Dtos;
using Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace Mvc.ViewModels
{
    public class AllEventsViewModel
    {
        // includes _LogFilterPartialViewModel

        [Display(Name = "Facility")]
        public int FacilNo { get; set; }

        [Display(Name = "Log Type")]
        public int LogTypeNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Primary? Check for Yes.")]
        public Boolean OperatorType { get; set; }

        public SelectList facilNos { get; set; } = new SelectList(new List<SelectListItem>(), "Value", "Text");
        public SelectList logTypeNos { get; set; } = new SelectList(new List<SelectListItem>(), "Value", "Text");

        public int Count { get; set; }

        public List<ViewAllEventsCurrent> AllEventList { get; set; } = new List<ViewAllEventsCurrent>();

        public IPagedList<List<ViewAllEventsCurrent>> AllEventsPagedList { get; set; } = new PagedList<List<ViewAllEventsCurrent>>(new List<List<ViewAllEventsCurrent>>(), 1, 10);

        public AllEventDetailsDto AllEventDetails { get; set; } = new AllEventDetailsDto();
    }
}
