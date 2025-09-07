using Microsoft.AspNetCore.Mvc;
using Prototype.Models;
using Prototype.Application.Interfaces.IServices;

namespace Prototype.Controllers;

public class CheckInController(ICoreService coreService, ILogger<CheckInController> logger) : BaseController
{
    private readonly ICoreService _coreService = coreService;
    private readonly ILogger<CheckInController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var facilities = await LoadFacilitiesAsync();
        var model = new CheckInViewModel
        {
            UserName = "Chen,Lihan",
            Facilities = facilities
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(CheckInViewModel model)
    {
        model.Facilities = await LoadFacilitiesAsync(); // repopulate for redisplay

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _logger.LogInformation("CheckIn: User={User} Shift={AssignedShift} Assignment={AssignedOperatorType} FacilNo={FaciNo}",
            model.UserName, model.AssignedShift, model.AssignedOperatorType, model.FacilNo);

        // TODO: Persist check-in (e.g., save to DB)
        TempData["CheckInSuccess"] = "Check-in recorded.";

        return RedirectToAction(nameof(Confirmed));
    }

    [HttpGet]
    public IActionResult Confirmed()
    {
        if (TempData["CheckInSuccess"] is null)
            return RedirectToAction(nameof(Index));

        return View();
    }

    //private async Task<List<FacilOption>> LoadFacilitiesAsync()
    //{
    //    try
    //    {
    //        var plants = await _coreService.GetAllPlants();
    //        return plants
    //            .Select(f => new FacilOption(((int)f), f.ToString()))
    //            .OrderBy(f => f.FacilNo)
    //            .ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Failed to load facilities, using fallback.");
    //        return [new FacilOption(1, "Fallback A"), new FacilOption(2, "Fallback B")];
    //    }
    //}
}
