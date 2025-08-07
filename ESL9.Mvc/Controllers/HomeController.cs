using Application.Interfaces.IServices;
using ESL9.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Controllers;
using Mvc.Models.Enum;
using System.Diagnostics;
using System.Security.Claims;

namespace ESL9.Mvc.Controllers;

[Authorize]
public class HomeController(ICoreService coreService, 
                            ILogger<HomeController> logger) : BaseController<HomeController>(coreService, logger)
{
    private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));
    private readonly ILogger<HomeController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    
    //private int _facilNo;
    private string facilName = string.Empty;
    private bool showAlert;

    public IActionResult Index(string returnUrl, bool showAlert = false)   // this action checks if necessary parameters are available before redirecting to AllEvents/
    {
        //string? userId = GetClaimValue(HttpContext.User, ClaimTypes.NameIdentifier);

        // Get the FacilNo from claim.Type == "FacilNosession or set it to null if not available
        int? _facilNo = HttpContext.Session.GetInt32("SelectedFacilNo");

        string? userName = UserName; // GetClaimValue(HttpContext.User, ClaimTypes.Name) ?? string.Empty;

        //string? userId = GetClaimValue(User, ClaimTypes.UserID) ?? UserID ?? string.Empty; // Should check if the User has ClaimTypes.UserID, set userID according to the claim if not null; set to UserID from BaseController if null and update the claim

        var userRole = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;


        // https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal?view=net-9.0
        if (HttpContext.User is ClaimsPrincipal principal)
        {
            //User.Claims.TryGetValue(ClaimTypes.Role, out var userRole); 
            //    ? int.TryParse(facilNoClaim, out var facilNo) ? facilNo : (int?)null 
            //    : null;
            // Change this line:
            //string userName = GetClaimValue(HttpContext.User, ClaimTypes.Name);

            // To this, using null-coalescing operator to ensure non-null assignment:
            //string userName = GetClaimValue(HttpContext.User, ClaimTypes.Name) ?? string.Empty;
            //foreach (Claim claim in principal.Claims)
            //{
            //    // Response.WriteAsync("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
            //}
        }

        // note: claims make up claimsIdentity, which then makes up the claimprincipal of identity as an user object

        if (ShowAlert)
        {
            ViewBag.ShowAlert = true;
            ViewBag.Alert = "You must select a facility first!";
        }

        // ToDo: TryGetValue claim.Type for facilno claim.TryGetValue("FacilNo", out var value) && value.Length > 0)
        // Redirect to select a plant by setting true if facilITY has not be selected

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
