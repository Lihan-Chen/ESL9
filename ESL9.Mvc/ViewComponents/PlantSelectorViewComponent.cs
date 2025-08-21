// ESL9.Mvc/ViewComponents/PlantSelectorViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Constants;

public class PlantSelectorViewComponent : ViewComponent
{

    public async Task<IViewComponentResult> InvokeAsync(int? selectedFacilNo = null)
    {
        var plants = Enum.GetValues<Facil>()
            .Cast<Facil>()
            .Select(p => new FacilSelectViewModel
            {
                FacilNo = (int)p,
                FacilName = FacilExtensions.GetFacilName(p),
                IsSelected = selectedFacilNo.HasValue && selectedFacilNo.Value == (int)p
            })
            .ToList();

        return await Task.FromResult(View(plants));
    }
}

