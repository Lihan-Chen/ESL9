using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prototype.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Prototype.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private const string Message = "User is in the ESL_ADMIN role.";
        private readonly IClaimsTransformation _claimTransformation;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IClaimsTransformation claimTransformation, ILogger<HomeController> logger)
        {
            _claimTransformation = claimTransformation;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            foreach (Claim claim in User.Claims)
            {
                _logger.LogInformation("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
            }

            var facilNoClaim = User.Claims.FirstOrDefault(c => c.Type == "defaultfacilno")?.Value;

            if (facilNoClaim != null)
            {
                _logger.LogInformation("Default Facility No: " + facilNoClaim);
            }
            else
            {
                _logger.LogInformation("Facility claim not found.");
                var transformedPrincipal = await _claimTransformation.TransformAsync(User);
            }            

            //if (User.HasClaim(c => c.Type == "userID"))
            //{
            //    string userID = "U06337";

            //    // Fix: Use the injected _claimTransformation and await the TransformAsync method
            //    var transformedPrincipal = await _claimTransformation.TransformAsync(User);

            //    _logger.LogInformation("User ID: " + userID);
            //}

            //if (User.HasClaim(c => c.Type == "FacilNo"))
            //{
            //    int defaultFacilNo = 1;

            //    // Fix: Use the injected _claimTransformation and await the TransformAsync method
            //    var transformedPrincipal = await _claimTransformation.TransformAsync(User);

            //    _logger.LogInformation("User DefaultFacilNo: " + defaultFacilNo);
            //}

            //if (User.HasClaim(c => c.Type == "role"))
            //{
            //    string userRole = "ESL_OPERATOR";

            //    // Fix: Use the injected _claimTransformation and await the TransformAsync method
            

            //    _logger.LogInformation("User Role: " + userRole);
            //}

            // not working with IsInRole
            //if (User.IsInRole("ESL_ADMIN"))
            //{
            //    _logger.LogInformation("IS IN ROLE ADMIN");
            //}

            if (User.HasClaim(c => c.Type == "role"))  
            {
                _logger.LogInformation("User has a custom role claim");
            }

            string? UserID = User.Identity?.Name;

            _logger.LogInformation($"User is {UserID}");

            if (User.Claims?.FirstOrDefault(c => c.Type == "role")?.Value is not null)
            {
                var roleValue = User.Claims?.FirstOrDefault(c => c.Type == "role")?.Value;
            }

            return View();
        }

        public IActionResult CheckIn()
        {
            ViewData["Title"] = "Check In";

            return View();
        }

        [HttpPost]
        public Task<IActionResult> CheckaIn([FromForm]CheckInViewModel checkInViewModel)
        {
            if (checkInViewModel == null)
            {
                _logger.LogWarning("CheckInViewModel is null.");
                return Task.FromResult<IActionResult>(BadRequest("Invalid check-in data."));
            }

            ViewData["Title"] = "Check Out";

            var returnUrl = TempData["ReturnUrl"] as string ?? Url.Action("Index", "AllEvents") ?? "/";

            return Task.FromResult<IActionResult>(Redirect(returnUrl));
        }

        public IActionResult SelectPlant()
        {
            ViewData["Title"] = "Please select one facility from the list -";
            
            int? DefaultFacilNo = null;
            var defaultFacilNoValue = User.Claims.FirstOrDefault(c => c.Type == "defaultfacilno")?.Value;

            if (int.TryParse(defaultFacilNoValue, out int parsedFacilNo))
            {
                DefaultFacilNo = parsedFacilNo;
            }

            var PriorFacilNo = HttpContext.Session.GetInt32("SelectedFacilNo");

            // Default FacilNo to Session value first if available, otherwise use the default from claims
            if (PriorFacilNo.HasValue)
            {
                ViewBag.SelectedPlant = PriorFacilNo.Value;
            }
            else
            {
                ViewBag.SelectedPlant = DefaultFacilNo; // Handle the case where no plant is selected
            }

            ViewBag.ReturnUrl = TempData["ReturnUrl"] as string ?? Url.Action("Index", "AllEvents");

            return View();
        }

        [HttpPost]
        public Task<IActionResult> SetPlant(int selectedFacilNo)
        {
            //if (!Enum.IsDefined(typeof(Facil), selectedFacilNo))
            if (selectedFacilNo < 1 || selectedFacilNo > 13) // Assuming valid FacilNo range is 1 to 5
            {
                _logger.LogWarning("Invalid plant selection attempted: {FacilNo}", selectedFacilNo);
                return Task.FromResult<IActionResult>(BadRequest("Invalid plant selection"));
            }

             //ModelState.ValidationState = ModelState.IsValid ? ModelValidationState.Valid : ModelValidationState.Invalid;

            try
            {
                // Store the selected plant in session
                HttpContext.Session.SetInt32("SelectedFacilNo", selectedFacilNo);
                //FacilNo = HttpContext.Session.GetInt32("SelectedFacilNo") ?? 0; // selectedPlant;

                // Log the plant selection
                _logger.LogInformation("User {UserId} selected plant {PlantId}", User.Claims.First(c => c.Type == "userid"), selectedFacilNo);

                // Get return URL from TempData, fallback to default route
                var returnUrl = TempData["ReturnUrl"] as string ?? Url.Action("Index", "AllEvents") ?? "/";

                return Task.FromResult<IActionResult>(Redirect(returnUrl));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting plant selection for user {UserId}", User.Claims.First(c => c.Type == "userid"));
                return Task.FromResult<IActionResult>(RedirectToAction(nameof(Error)));
            }
        }

        public IActionResult Privacy()
        {
            foreach (Claim claim in User.Claims)
            {
                _logger.LogInformation("From PrivacyController - CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
            }

            return View();
        }

        public IActionResult Test()
        {
            foreach (Claim claim in User.Claims)
            {
                
                _logger.LogInformation("From TestController - CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
            }

            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
