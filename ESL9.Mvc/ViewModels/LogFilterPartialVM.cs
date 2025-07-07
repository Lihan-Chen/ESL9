using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Mvc.ViewModels
{
    public partial record LogFilterPartialViewModel
    {
        [Required]
        [Display(Name = "Facility")]
        public int? SelectedFacilNo { get; set; }

        [Display(Name = "Log Type")]
        public int? SelectedLogTypeNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; } = DateTime.Now.AddDays(-1);

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; } = DateTime.Now.AddDays(1);

        [Display(Name = "Primary Operator?")]
        public bool IsPrimaryOperator { get; set; }

        [Display(Name = "Keyword")]
        [RegularExpression("([a-zA-Z0-9_]+)", ErrorMessage = "Enter only alphabets and numbers of Keywords")]  //[a-zA-Z0-9_] or "\w"
        public string? CurrentFilter { get; set; }

        public SelectList FacilSelectList { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");

        public SelectList LogTypeSelectList { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");

    }
}

//Ask Copilot to complete the code
//you are an experienced full stack application developer of asp.net core mvc. 
//    Create a search controller and views with a viewmodel that consists of LogFilterPartialViewModel and list of VIEW_ALLEVENTS_CURRENT.
//    If possible, use AJAX to query for the new result and load in the search result area when user selects different filter values.
//    LogFilterPartialViewModelas is used as a data selection filter consisting of facility selectlist, start date, end date, and a keyword inputs with some default values. 
//    Based on the default values, create a search result list of VIEW_ALLEVENTS_CURRENT underneath on first load.
//public List<VIEW_ALLEVENTS_CURRENT> Search(LogFilterPartialViewModel filter)
//{
//    // Example LINQ filtering logic
//    var query = _context.Current_AllEvents.AsQueryable();

//    if (filter.SelectedFacilNo.HasValue)
//        query = query.Where(x => x.FacilNo == filter.SelectedFacilNo.Value);

//    if (filter.SelectedLogTypeNo.HasValue)
//        query = query.Where(x => x.LogTypeNo == filter.SelectedLogTypeNo.Value);

//    if (filter.StartDate.HasValue)
//        query = query.Where(x => x.EventDate >= filter.StartDate.Value);

//    if (filter.EndDate.HasValue)
//        query = query.Where(x => x.EventDate <= filter.EndDate.Value);

//    if (!string.IsNullOrWhiteSpace(filter.CurrentFilter))
//        query = query.Where(x => x.Keywords.Contains(filter.CurrentFilter));

//    return query.ToList();
//}
//    If possible, use FacilSelectorViewComponent and LogTypeSelectgorViewComponent in the LogFilterPartial form.
