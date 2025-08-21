using Application.Dtos;
using Application.Interfaces.IServices;
using ESL9.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc;
using Mvc.Controllers;
using Mvc.Models;
using Mvc.Models.Constants;
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

    // Fix for CS0029 and CS8600 in Index method
    [HttpGet(Name = "Index")]
    public IActionResult Index(string returnUrl, bool showAlert = false)
    {
        ClaimsPrincipal user = HttpContext.User;

        string? userName = UserName;

        string? userID = _coreService.GetEmployeeIDByEmployeeName(userName!);

        string userMode = _coreService.HasAnyRoles(userID!).Result ?  "OperatorMode" : "ViewerMode"; // Default to Viewer if role is not found

        // Fix: Await the SetClaim method and handle possible null return
        var updatedUserTask = SetClaim(user, AppConstants.UserIDClaimType, userID);
        if (updatedUserTask != null)
        {
            var updatedUser = updatedUserTask.Result;
            if (updatedUser != null)
            {
                user = updatedUser;
            }
        }

        foreach (Claim claim in user.Claims)
        {
            _logger.LogInformation("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
        }

        if (!showAlert.Equals(true))
        {
            showAlert = false;
        }

        int? _facilNo = DefaultFacilNo ?? FacilNo ?? null;

        if (_facilNo is null)
        {
            if (showAlert)
            {
                ViewBag.ShowAlert = true;
                ViewBag.Alert = "You must select a facility first!";
            }

            ViewBag.ShowPlantMenu = _facilNo == null;
            ViewBag.Message = "Please select one facility from the list - ";
            ViewBag.ReturnUrl = returnUrl; // this.Url;

            return View("SelectPlant");
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
    public async Task<IActionResult> SetPlant(int selectedFacilNo, bool rememberMe = false)
    {
        if (!Enum.IsDefined(typeof(Facil), selectedFacilNo))
        {
            _logger.LogWarning("Invalid plant selection attempted: {FacilNo}", selectedFacilNo);
            return await Task.FromResult<IActionResult>(BadRequest("Invalid plant selection"));
        }

        try
        {
            // Handle claim
            var identity = (ClaimsIdentity)User.Identity!;

            // Remove old claims if exists
            var oldClaim = identity.FindFirst("defaultno");
            if (oldClaim != null)
                identity.RemoveClaim(oldClaim);

            // Add new claim
            identity.AddClaim(new Claim("defaultfacilno", selectedFacilNo.ToString()));

            var userID = UserID; // GetClaimValue(HttpContext.User, ClaimTypes.UserID) ?? UserID ?? string.Empty;

            var facilNo = selectedFacilNo; // GetClaimValue(HttpContext.User, "defaultfacilno") ?? FacilNo.ToString() ?? string.Empty;

            var roleClaimValue = _coreService.GetRole(userID!, facilNo).Result ?? string.Empty; // role is dependent on userID and facilNo (role only exists for a facility)

            if (!string.IsNullOrEmpty(roleClaimValue) && !User.HasClaim(c => c.Type == AppConstants.RoleClaimType && c.Value == roleClaimValue))
            {
                identity.AddClaim(new Claim(AppConstants.RoleClaimType, roleClaimValue));
            }

            // Set authentication properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe, // <-- This enables "Remember Me"
                ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddDays(14) : DateTimeOffset.UtcNow.AddHours(1)
            };

            // Sign in
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), //principal,
                authProperties
            );


            // Store the selected plant in session
            HttpContext.Session.SetInt32("SelectedFacilNo", selectedFacilNo);

            // write to response cookie for the selected plant to be picked up by the ClaimsTransformation
            HttpContext.Response.Cookies.Append("SelectedFacilNo", selectedFacilNo.ToString());
            // Update the FacilNo property in the base controller
            FacilNo = HttpContext.Session.GetInt32("SelectedFacilNo") ?? 0; // selectedPlant;

            // Log the plant selection
            _logger.LogInformation("User {UserId} selected plant {PlantId}", UserID, FacilNo);

            // Get return URL from TempData, fallback to default route
            var returnUrl = TempData["ReturnUrl"] as string ?? Url.Action("Index", "AllEvents");

            return await Task.FromResult<IActionResult>(Redirect(returnUrl!));
            
            // Redirect or return as needed
            //return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting plant selection for user {UserId}", UserID);
            return await Task.FromResult<IActionResult>(RedirectToAction(nameof(Error)));
        }
    }

    public IActionResult Privacy() => View();
    
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //#region Helpers

    //private new string? GetClaimValue(ClaimsPrincipal user, string claimType)
    //{
    //    return user.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
    //}

    //private static string? GetClaimValue(ClaimsPrincipal user, Func<Claim, bool> predicate)
    //{
    //    return user.Claims.FirstOrDefault(predicate)?.Value;
    //}

    //private static Claim? GetClaim(ClaimsPrincipal user, string claimType)
    //{
    //    return user.Claims.FirstOrDefault(c => c.Type == claimType);
    //}

    //private Task<ClaimsPrincipal>? SetClaim(ClaimsPrincipal user, string? claimType, string? claimValue)
    //{
    //    if (string.IsNullOrEmpty(claimType) || string.IsNullOrEmpty(claimValue))
    //    {
    //        return null;
    //    }

    //    var identity = (ClaimsIdentity)user.Identity!;

    //    // Remove old claim if it exists
    //    var oldClaim = identity.FindFirst(claimType);
    //    if (oldClaim != null)
    //    {
    //        identity.RemoveClaim(oldClaim);
    //    }

    //    // Add new claim
    //    var newClaim = new Claim(claimType, claimValue);
    //    identity.AddClaim(newClaim);

    //    // Sign in again to update claims
    //    HttpContext.SignInAsync(
    //        CookieAuthenticationDefaults.AuthenticationScheme,
    //        new ClaimsPrincipal(identity)
    //    ).Wait(); // Wait for the sign-in to complete

    //    return Task.FromResult(new ClaimsPrincipal(identity));
    //}

    //// Fix the method signature to use IEnumerable<KeyValuePair<string, string>> instead of IEnumerable<string, string>
    //private Task<ClaimsPrincipal> SetClaim(ClaimsPrincipal user, IEnumerable<KeyValuePair<string, string>> claims, bool rememberMe)
    //{
    //    foreach (var c in claims)
    //    {
    //        if (string.IsNullOrEmpty(c.Key) || string.IsNullOrEmpty(c.Value))
    //        {
    //            continue; // Skip empty claims
    //        }
    //        user = SetClaim(user, c.Key, c.Value).Result;
    //    }

    //    var identity = (ClaimsIdentity)user.Identity!;

    //    // Set authentication properties
    //    var authProperties = new AuthenticationProperties
    //    {
    //        IsPersistent = rememberMe,
    //        ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddDays(14) : DateTimeOffset.UtcNow.AddHours(1)
    //    };

    //    // Sign in again to update claims
    //    HttpContext.SignInAsync(
    //        CookieAuthenticationDefaults.AuthenticationScheme,
    //        new ClaimsPrincipal(identity),
    //        authProperties
    //    ).Wait();

    //    return Task.FromResult(new ClaimsPrincipal(identity));
    //}

    //private Task<ClaimsPrincipal>? SetClaim(ClaimsPrincipal user, Func<Claim, bool> predicate, string? claimValue, bool? rememberMe = false)
    //{
    //    if (string.IsNullOrEmpty(claimValue))
    //    {
    //        return null;
    //    }
    //    var identity = (ClaimsIdentity)user.Identity!;
    //    // Remove old claim if it exists
    //    var oldClaim = identity.Claims.FirstOrDefault(predicate);
    //    if (oldClaim != null)
    //    {
    //        identity.RemoveClaim(oldClaim);
    //    }
    //    // Add new claim
    //    var newClaim = new Claim(predicate.Method.Name, claimValue);
    //    identity.AddClaim(newClaim);

    //    // Set authentication properties
    //    var authProperties = new AuthenticationProperties
    //    {
    //        IsPersistent = rememberMe ?? false, // <-- This enables "Remember Me"
    //        ExpiresUtc = rememberMe == true ? DateTimeOffset.UtcNow.AddDays(14) : DateTimeOffset.UtcNow.AddHours(1)
    //    };

    //    // Sign in again to update claims
    //    HttpContext.SignInAsync(
    //        CookieAuthenticationDefaults.AuthenticationScheme,
    //        new ClaimsPrincipal(identity),
    //        authProperties
    //    ).Wait(); // Wait for the sign-in to complete

    //    // Return the Principal with updated claims
    //    return Task.FromResult(new ClaimsPrincipal(identity));
    //}

    //private void SetSessionValue(string key, object value)
    //{
    //    if (value is null)
    //    {
    //        HttpContext.Session.Remove(key);
    //    }
    //    else
    //    {
    //        HttpContext.Session.SetString(key, value.ToString()!);
    //    }
    //}

    //private T? GetSessionValue<T>(string key) where T : class
    //{
    //    if (HttpContext.Session.TryGetValue(key, out var value))
    //    {
    //        return value as T;
    //    }
    //    return null;
    //}

    //#endregion


}
