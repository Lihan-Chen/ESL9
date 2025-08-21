// ESL9.Mvc/ViewComponents/LogTypeSelectorViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Enum;

public class LogTypeSelectorViewComponent : ViewComponent
{
    //private readonly IFacilityRepository _facilityRepository;

    //public LogTypeSelectorViewComponent(IFacilityRepository facilityRepository)
    //{
    //    _facilityRepository = facilityRepository;
    //}

    public async Task<IViewComponentResult> InvokeAsync(int? selectedLogTypeNo = null)
    {
        var LogTypes = Enum.GetValues<LogType>()
            .Cast<LogType>()
            .Select(l => new LogTypeSelectViewModel
            {
                LogTypeNo = (int)l,
                LogTypeName = LogTypeExtensions.GetLogTypeName(l),
                IsSelected = selectedLogTypeNo.HasValue && selectedLogTypeNo.Value == (int)l
            })
            .ToList();

        return await Task.FromResult(View(LogTypes));
    }
}
