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

    public async Task<IViewComponentResult> InvokeAsync(int? selectedLogType = null)
    {
        var LogTypes = Enum.GetValues<LogType>()
            .Select(p => new LogTypeSelectViewModel
            {
                Id = (int)p,
                Name = LogTypeExtensions.GetLogTypeName(p),
                IsSelected = selectedLogType.HasValue && selectedLogType.Value == (int)p
            })
            .ToList();

        return await Task.FromResult(View(LogTypes));
    }
}
