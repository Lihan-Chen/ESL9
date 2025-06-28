using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Enum;

public class FacilSelectorViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(int? selectedPlantId = null)
    {
        var plants = Enum.GetValues(typeof(Plant))
            .Cast<Plant>()
            .Select(p => new PlantSelectViewModel
            {
                Id = (int)p,
                Name = p.ToString(),
                IsSelected = selectedPlantId.HasValue && (int)p == selectedPlantId.Value
            })
            .ToList();

        return View(plants);
    }
}
