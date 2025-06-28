// ESL9.Mvc/ViewComponents/PlantSelectorViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Enum;

public class PlantSelectorViewComponent : ViewComponent
{
    //private readonly IFacilityRepository _facilityRepository;

    //public PlantSelectorViewComponent(IFacilityRepository facilityRepository)
    //{
    //    _facilityRepository = facilityRepository;
    //}

    public async Task<IViewComponentResult> InvokeAsync(int? selectedPlantNo = null)
    {
        var plants = Enum.GetValues<Plant>()
            .Select(p => new PlantSelectViewModel
            {
                Id = (int)p,
                Name = PlantExtensions.GetPlantName(p),
                IsSelected = selectedPlantNo.HasValue && selectedPlantNo.Value == (int)p
            })
            .ToList();

        return await Task.FromResult(View(plants));
    }
}

