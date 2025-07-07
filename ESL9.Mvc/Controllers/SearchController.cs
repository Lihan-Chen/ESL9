using ESL9.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
    public class SearchController : Controller
    {
        private readonly EslDbContext _context;

        public SearchController(EslDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var filter = new LogFilterPartialViewModel();
            // Optionally set default values or populate select lists here  

            var results = _context.Current_AllEvents.Where(c => c.FACILNO == filter.SelectedFacilNo &&
                                                           c.LOGTYPENO == filter.SelectedLogTypeNo &&
                                                           c.EVENTDATE >= filter.StartDate &&
                                                           c.EVENTDATE <= filter.EndDate &&
                                                           (string.IsNullOrEmpty(filter.CurrentFilter) ||
                                                            ContainsFilter(c.SUBJECT, filter.CurrentFilter) ||
                                                            ContainsFilter(c.DETAILS, filter.CurrentFilter)))
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
            var results = _context.Current_AllEvents.Where(c => c.FACILNO == filter.SelectedFacilNo &&
                                                           c.LOGTYPENO == filter.SelectedLogTypeNo &&
                                                           c.EVENTDATE >= filter.StartDate &&
                                                           c.EVENTDATE <= filter.EndDate &&
                                                           (string.IsNullOrEmpty(filter.CurrentFilter) ||
                                                            ContainsFilter(c.SUBJECT, filter.CurrentFilter) ||
                                                            ContainsFilter(c.DETAILS, filter.CurrentFilter)))
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

