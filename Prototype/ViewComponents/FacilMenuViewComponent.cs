using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prototype.Core.Models.BusinessEntities.Enum;
using Prototype.ViewModels;

namespace Prototype.ViewComponents
{
    public class FacilMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? selectedFacilNo)
        {
            var facils = Enum.GetValues<Facil>()
                .Cast<Facil>()
                .Select(f => new SelectListItem
                {
                    Value = ((int)f).ToString(),
                    Text = f.ToString(),
                    Selected = selectedFacilNo.HasValue && (int)f == selectedFacilNo.Value
                })
                .ToList();

            var facilMenuViewModel = new FacilMenuViewModel
            {
                UserID = HttpContext.Session.GetString("UserID"),
                FacilOptions = facils,
                // SelectedFacilNo = selectedFacilNo
            };

            // Fix: Use Task.FromResult to wrap the View result in a Task  
            return await Task.FromResult(View(facilMenuViewModel));
        }
    }


}
