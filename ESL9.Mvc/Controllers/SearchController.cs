using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
    public class SearchController : Controller
    {
        private readonly EslDbContext _context;
        private readonly EslViewContext _view;

        public SearchController(EslDbContext context, EslViewContext view)
        {
            _context = context;
            _view = view;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var filter = new LogFilterPartialViewModel();
            // Optionally set default values or populate select lists here  

            var results = _view.Current_AllEvents.Where(c => c.FacilNo == filter.SelectedFacilNo &&
                                                           c.LogTypeNo == filter.SelectedLogTypeNo &&
                                                           c.EventDate >= filter.StartDate &&
                                                           c.EventDate <= filter.EndDate &&
                                                           (string.IsNullOrEmpty(filter.CurrentFilter) ||
                                                            ContainsFilter(c.Subject, filter.CurrentFilter) ||
                                                            ContainsFilter(c.Details, filter.CurrentFilter)))
                .ToList();

            var vm = new AllEventsSearchViewModel
            {
                Filter = filter,
                Results = results
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Search(LogFilterPartialViewModel filter)
        {
            var results = _view.Current_AllEvents.Where(c => c.FacilNo == filter.SelectedFacilNo &&
                                                           c.LogTypeNo == filter.SelectedLogTypeNo &&
                                                           c.EventDate >= filter.StartDate &&
                                                           c.EventDate <= filter.EndDate &&
                                                           (string.IsNullOrEmpty(filter.CurrentFilter) ||
                                                            ContainsFilter(c.Subject, filter.CurrentFilter) ||
                                                            ContainsFilter(c.Details, filter.CurrentFilter)))
                .ToList();
            return PartialView("_SearchResults", results);
        }

        private static bool ContainsFilter(string? field, string? filter)
        {
            return field != null && filter != null && field.Contains(filter);
        }
    }
    //    HttpContext.Session.SetInt32("SelectedFacilNo", logFilterPartial.SelectedFacilNo ?? 0);
//                //HttpContext.Session.SetInt32("SelectedLogTypeNo", logFilterPartial.SelectedLogTypeNo ?? 0);
//            }
//ViewData["Title"] = "Log Filter";
//return PartialView("_LogFilterPartial", logFilterPartial);
}

