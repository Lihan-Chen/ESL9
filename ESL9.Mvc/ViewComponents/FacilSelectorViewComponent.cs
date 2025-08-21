using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Constants;

public class FacilSelectorViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(int? selectedFacilNo)
    {
        var facils = Enum.GetValues<Facil>()
            .Cast<Facil>()
            .Select(f => new FacilSelectViewModel
            {
                FacilNo = (int)f,
                FacilName = f.ToString(),
                IsSelected = selectedFacilNo.HasValue && (int)f == selectedFacilNo.Value
            })
            .ToList();

        // Fix: Use Task.FromResult to wrap the View result in a Task  
        return await Task.FromResult(View(facils));
    }
}
