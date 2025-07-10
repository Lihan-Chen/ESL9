using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ESL9.Mvc.Models;
using Mvc.Controllers;
using Mvc.Models.Enum;

namespace ESL9.Mvc.Controllers;

[Authorize]
public class HomeController(// IFacilityRepository facilityRepository, 
                            ILogger<HomeController> logger) : BaseController
{
    private readonly ILogger<HomeController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    // private readonly IFacilityRepository _facilityRepository = facilityRepository ?? throw new ArgumentNullException(nameof(facilityRepository));

    //private int _facilNo;
    private string facilName = string.Empty;
    private bool showAlert;

    public IActionResult Index(string returnUrl, bool showAlert = false)   // this only checks necessary parameters are available before redirecting to AllEvents/
    {
        if (ShowAlert)
        {
            ViewBag.ShowAlert = true;
            ViewBag.Alert = "You must select a facility first!";
        }
        
        // Redirect to select a plant by setting true if facilName is not found
        if (FacilNo is null)
        {
            // user is not an operator, redirect to SelectPlant view as viewonly
            if (!IsUserAnOperator)
            {
                // facilName = PlantsDictionary.Plants[1].PlantName; // default to first plant
                ViewBag.ShowPlantMenu = true;
                ViewBag.Message = "Please select one facility from the list - ";
                ViewBag.ReturnUrl = this.Url;
                return View("SelectPlant");
            }

            ViewBag.Message = "Please check in for your shift - ";
            ViewBag.ReturnUrl = returnUrl ?? Url.Action("Index", "AllEvents");

            return View("CheckIn");
        }

        return RedirectToAction("Index", "AllEvents");
    }

    public IActionResult CheckIn()
    {
        ViewData["Title"] = "Check In";

        return View();
    }

    public IActionResult SelectPlant()
    {
        ViewData["Title"] = "Please select one facility from the list -";

        if (HttpContext.Session.TryGetValue("SelectedPlant", out byte[]? selectedPlantBytes))
        {
            // Convert the byte array to an integer
            int selectedPlant = BitConverter.ToInt32(selectedPlantBytes, 0);
            ViewBag.SelectedPlant = selectedPlant;
        }
        else
        {
            ViewBag.SelectedPlant = null; // Handle the case where no plant is selected
        }

        ViewBag.ReturnUrl = TempData["ReturnUrl"] as string ?? Url.Action("Index", "AllEvents");

        return View();
    }

    [HttpPost]
    public Task<IActionResult> SetPlant(int selectedFacilNo)
    {
        if (!Enum.IsDefined(typeof(Facil), selectedFacilNo))
        {
            _logger.LogWarning("Invalid plant selection attempted: {FacilNo}", selectedFacilNo);
            return Task.FromResult<IActionResult>(BadRequest("Invalid plant selection"));
        }

        try
        {
            // Store the selected plant in session
            HttpContext.Session.SetInt32("SelectedFacilNo", selectedFacilNo);
            FacilNo = HttpContext.Session.GetInt32("SelectedFacilNo") ?? 0; // selectedPlant;

            // Log the plant selection
            _logger.LogInformation("User {UserId} selected plant {PlantId}", UserID, FacilNo);

            // Get return URL from TempData, fallback to default route
            var returnUrl = TempData["ReturnUrl"] as string ?? Url.Action("Index", "AllEvents");

            return Task.FromResult<IActionResult>(Redirect(returnUrl!));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting plant selection for user {UserId}", UserID);
            return Task.FromResult<IActionResult>(RedirectToAction(nameof(Error)));
        }
    }

    public IActionResult Privacy() => View();
    
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
