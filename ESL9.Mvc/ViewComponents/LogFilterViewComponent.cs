using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Enum;
using Mvc.ViewModels;

namespace Mvc.ViewComponents
{
    public class LogFilterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(LogFilterPartialViewModel logFilterPartial)
        {
            if (logFilterPartial == null)
            {
                logFilterPartial = new LogFilterPartialViewModel
                {
                    SelectedFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo"),
                    SelectedLogTypeNo = HttpContext.Session.GetInt32("SelectedLogTypeNo"),
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(1)
                };
            }

            var facils = Enum.GetValues<Facil>()
                .Cast<Facil>()
                .Select(f => new FacilSelectViewModel
                {
                    FacilNo = (int)f,
                    FacilName = f.ToString(),
                    IsSelected = logFilterPartial.SelectedFacilNo.HasValue && (int)f == logFilterPartial.SelectedFacilNo.Value
                })
                .ToList();

            var LogTypes = Enum.GetValues<LogType>()
            .Cast<LogType>()
            .Select(l => new LogTypeSelectViewModel
            {
                LogTypeNo = (int)l,
                LogTypeName = LogTypeExtensions.GetLogTypeName(l),
                IsSelected = logFilterPartial.SelectedLogTypeNo.HasValue && logFilterPartial.SelectedLogTypeNo.Value == (int)l
            })
            .ToList();

            // Fix: Use Task.FromResult to wrap the View result in a Task  
            return await Task.FromResult(View(logFilterPartial));
        }
    }
}