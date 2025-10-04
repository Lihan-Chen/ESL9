using Application.Interfaces.IServices;
using Core.Models.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Mvc.Extensions;
using Mvc.Models;
using Mvc.Models.Enum;
using Mvc.ViewModels;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ValidateAntiForgeryTokenAttribute = Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute;

namespace Mvc.Controllers;

[Authorize]
public class HomeController(ICoreService coreService, 
                            ILogger<HomeController> logger) : BaseController<HomeController>(coreService, logger)
{
    private readonly ICoreService _coreService = coreService ?? throw new ArgumentNullException(nameof(coreService));
    private readonly ILogger<HomeController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    
    //private int _facilNo;
    private string facilName = string.Empty;
    private bool showAlert;

    private bool rememberMe = true;

    // Define shift start and end times locally to avoid access issues
    //DateTime shiftStartTime = DateTime.Today.Add(TimeSpan.Parse(AppConstants.DayShiftStartText));
    //DateTime shiftEndTime = DateTime.Today.Add(TimeSpan.Parse(AppConstants.DayShiftEndText));
    //DateTime now = DateTime.Now;

    [Authorize]
    [HttpGet(Name = "Index")]
    public IActionResult Index(string returnUrl, bool showAlert = false)
    {
        ClaimsPrincipal user = HttpContext.User;

        string? userName = UserName;

        if (IsNewSession) // where UserID Claim is not present
        {
            _logger.LogInformation("New session detected for user {UserName}", userName);

            if (UserID == null)
            {
                _logger.LogWarning("UserID claim not found in new session for user {UserName}", userName);
                return RedirectToAction("Error", "Home");
            }

            // Set UserID claim if not present with the value from UserID property and rememberMe = true
            var updatedUserTask = SetClaim(User, AppConstants.UserIDClaimType, UserID, rememberMe: true);

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


            // UserMode is stored in session for quick access
            string UserMode = _coreService.HasAnyRoles(UserID!).Result ? "Internal" : "Public"; // Default to Public if role is not found

            SessionExtensions.SetString(HttpContext.Session, AppConstants.UserModeSessionKey, UserMode);

            if (UserMode == "Public")
            {
                return RedirectToAction("Index", "Home", new { area = "Public" });
            }

            if (!showAlert.Equals(true))
            {
                showAlert = false;
            }

            if (FacilNo == null || FacilNo == 0)
            {

                if (showAlert)
                {
                    ViewBag.ShowAlert = true;
                    ViewBag.Alert = "You must select a facility and check in first!";
                }

                ViewBag.ShowPlantMenu = true;
                ViewBag.Message = "Please select one facility from the list - ";
                ViewBag.ReturnUrl = this.Url;

                return RedirectToAction("CheckIn"); // View("CheckIn");
            }
        }

        return RedirectToAction("Index", "AllEvents");
    }

    [HttpGet]
    public IActionResult CheckIn(string returnUrl)
    {
        // Get selectedFacilNo from user claim
        int? selectedFacilNo = HttpContext.Session.GetInt32(AppConstants.AssignedFacilNoSessionKey) ?? DefaultFacilNo ?? (int)Facil.OCC;

        ViewData["Title"] = "Check In";

        ViewBag.SelectedFacilNo = selectedFacilNo;

        // var _shift = DefaultShift; // Now >= ShiftStartTime && Now < ShiftEndTime ? Shift.Day : Shift.Night;

        var model = new CheckInModel
        {
            UserID = UserID!,
            // With this safer version:
            SelectedFacilNo = (Facil)selectedFacilNo,
            OperatorType = OperatorType.Primary,
            Shift = DefaultShift,
            RememberMe = rememberMe,
            FacilOptions = Enum.GetValues(typeof(Facil))
                .Cast<Facil>()
                .Select(f => new FacilSelectViewModel
                {
                    FacilNo = (int)f,
                    FacilName = FacilExtensions.GetFacilName(f),
                    IsSelected = f == (Facil)selectedFacilNo
                })
                .ToList()
        };

        return View("CheckIn", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CheckIn(CheckInModel model) // await LoadFacilitiesAsync(); // repopulate for redisplay
    {
        model.FacilOptions = Enum.GetValues(typeof(Facil))
                .Cast<Facil>()
                .Select(f => new FacilSelectViewModel
                {
                    FacilNo = (int)f,
                    FacilName = FacilExtensions.GetFacilName(f),
                    IsSelected = f == (Facil)model.SelectedFacilNo
                })
                .ToList(); 

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _logger.LogInformation("CheckIn: User={User} Shift={Shift} OperatorType={OperatorType} FacilityId={SelectedFacilNo}",
            model.UserID, model.Shift, model.OperatorType, model.SelectedFacilNo);

        try
        {
            // Get Role
            var role = await _coreService.GetRole(model.UserID!, (int)model.SelectedFacilNo) ?? UserRole;

            SessionExtensions.SetInt32(HttpContext.Session, AppConstants.AssignedShiftNoSessionKey, (int)model.Shift);

            SetSessionValue(AppConstants.AssignedShiftNoSessionKey, ((int)model.Shift));

            SetSessionValue(AppConstants.AssingedOperatorTypeSessionKey, ((int)model.OperatorType));

            HttpContext.Session.SetInt32(AppConstants.AssignedFacilNoSessionKey, (int)model.SelectedFacilNo);

            SetSessionValue(AppConstants.AssignedRoleSessionKey, role);

            if (DefaultFacilNo is null)
            {
                string _facilNoClaim = FacilHelper.GetFacilNumber(model.SelectedFacilNo).ToString();

                IEnumerable<KeyValuePair<string, string>> claims = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(AppConstants.DefaultFacilNoClaimType, _facilNoClaim),
                    new KeyValuePair<string, string>(AppConstants.DefaultRoleClaimType, role ?? string.Empty)
                };

                // Set claims and sign in again for DefaultFacilNo and DefaultRole
                await SetClaim(User, claims, rememberMe);
            }

            // Set default _LogFilterPartialViewModel
            // Serialize only the scalar/ filter fields; recreate SelectList from services.
            var _logInFilterPartialViewModel = new _LogFilterPartialViewModel()
            {
                SelectedFacilNo = (int)model.SelectedFacilNo, // ?? DefaultFacilNo ?? (int)Facil.OCC,
                StartDate = DefaultStartDate, // DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                EndDate = DefaultEndDate, // DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                OperatorType = true // Primary
            };

            // Pass the model using TempData or ViewData, or redirect to an action that accepts the model
            TempData["LogFilter"] = JsonSerializer.Serialize(_logInFilterPartialViewModel);

            var resolvedReturnUrl = TempData["returnUrl"] as string ?? Url.Action("Index", "AllEvents");

            return await Task.FromResult<IActionResult>(Redirect(resolvedReturnUrl!));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting plant selection for user {UserId}", UserID);
            return await Task.FromResult<IActionResult>(RedirectToAction(nameof(Error)));
        }
    }

    public IActionResult GoToAllEvents(_LogFilterPartialViewModel model)
    {
        // Store only simple values
        var transfer = new LogFilterTransferDto(
            model.SelectedFacilNo,
            model.SelectedLogTypeNo,
            model.StartDate,
            model.EndDate,
            model.OperatorType,
            model.CurrentFilter);

        TempData.Put("LogFilter", transfer);

        return RedirectToAction("Index", "AllEvents");
    }

    //[HttpGet]
    //public async Task<IActionResult> Confirmed()
    //{
    //    if (TempData["CheckInSuccess"] is null)
    //        return RedirectToAction(nameof(Index));

    //    // Set default _LogFilterPartialViewModel
    //    var _logInFilterPartialViewModel = new _LogFilterPartialViewModel()
    //    {
    //        SelectedFacilNo = HttpContext.Session.GetInt32(AppConstants.AssignedFacilNoSessionKey) ?? DefaultFacilNo ?? (int)Facil.OCC,
    //        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
    //        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
    //        OperatorType = true // Primary
    //    };

    //    var resolvedReturnUrl = TempData["returnUrl"] as string ?? Url.Action("Index", "AllEvents");

    //    // Pass the model using TempData or ViewData, or redirect to an action that accepts the model
    //    TempData["LogFilterPartialViewModel"] = JsonSerializer.Serialize(_logInFilterPartialViewModel);

    //    return await Task.FromResult<IActionResult>(Redirect(resolvedReturnUrl!));
    //}

    [HttpGet]
    public IActionResult CheckInm(string returnUrl)
    {
        int? selectedFacilNo = HttpContext.Session.GetInt32(AppConstants.AssignedFacilNoSessionKey) ?? DefaultFacilNo ?? (int)Facil.OCC;

        ViewData["Title"] = "Check In";

        ViewBag.SelectedFacilNo = selectedFacilNo;

        var _shift = DefaultShift; //now >= shiftStartTime && now < shiftEndTime ? Shift.Day : Shift.Night;

        // Build the model with defaults
        var model = new CheckInModel
        {
            UserID = UserID!,
            SelectedFacilNo = (Facil)selectedFacilNo,
            OperatorType = OperatorType.Primary,
            Shift = Shift.Day,
            RememberMe = rememberMe,
            FacilOptions = Enum.GetValues(typeof(Facil))
                .Cast<Facil>()
                .Select(f => new FacilSelectViewModel
                {
                    FacilNo = (int)f,
                    FacilName = FacilExtensions.GetFacilName(f),
                    IsSelected = f == (Facil)selectedFacilNo
                })
                .ToList()
        };

        return View("CheckIn", model);
    }

    

    // existing actions (Index, SelectPlant, SetPlant, etc.) remain unchanged

    public IActionResult SelectPlant(string returnUrl)
    {
        ViewData["Title"] = "Please select one facility from the list -";

        if (HttpContext.Session.TryGetValue("SelectedFacilNo", out byte[]? selectedFacilNoBytes))
        {
            // Convert the byte array to an integer
            int selectedFacilNo = BitConverter.ToInt32(selectedFacilNoBytes, 0);
            ViewBag.SelectedFacilNo = selectedFacilNo;
        }
        else
        {
            ViewBag.SelectedFacilNo = null; // Handle the case where no plant is selected
        }

        ViewBag.ReturnUrl = TempData["ReturnUrl"] as string ?? Url.Action("Index", "AllEvents");

        var facils = _coreService.GetFacilList().Result.AsQueryable().Where(f => f.FacilNo <= 13).ToList();

        return View(facils);
    }

    [HttpPost]
    public async Task<IActionResult> SetPlant(int selectedFacilNo, bool rememberMe = false, string? returnUrl = "Home/Register")
    {
        if (!Enum.IsDefined(typeof(Facil), selectedFacilNo))
        {
            _logger.LogWarning("Invalid plant selection attempted: {FacilNo}", selectedFacilNo);
            return await Task.FromResult<IActionResult>(BadRequest("Invalid plant selection"));
        }

        if (FacilNo == selectedFacilNo)
        {
            _logger.LogInformation("User {UserId} already has plant {PlantId} selected", UserID, selectedFacilNo);
            return await Task.FromResult<IActionResult>(Redirect(returnUrl));
        }
        else if (FacilNo != 0 && FacilNo != selectedFacilNo)
        {
            ////string[] _roles = Roles.GetRolesForUser(UserID);
            ////Roles.RemoveUserFromRoles(UserID, _roles);
            //IsSuperAdmin = false;
            //IsAdmin = false;
            //IsOperator = false;
        }

        //FacilNo = selectedFacilNo; // Set the selected facility number in the base controller

        showAlert = false; // Reset showAlert to false

            try
        {
            // Handle claim
            var identity = (ClaimsIdentity)User.Identity!;

            // Remove old claims if exists
            var oldClaim = identity.FindFirst(AppConstants.DefaultFacilNoClaimType);
            if (oldClaim != null)
                identity.RemoveClaim(oldClaim);

            // Add new claim
            identity.AddClaim(new Claim(AppConstants.DefaultFacilNoClaimType, selectedFacilNo.ToString()));

            var userID = UserID; // GetClaimValue(HttpContext.User, ClaimTypes.UserID) ?? UserID ?? string.Empty;

            var facilNo = selectedFacilNo; // GetClaimValue(HttpContext.User, "defaultfacilno") ?? FacilNo.ToString() ?? string.Empty;

            var role = _coreService.GetRole(userID!, facilNo).Result ?? string.Empty; // role is dependent on userID and facilNo (role only exists for a facility)

            //if (!string.IsNullOrEmpty(role) && !User.HasClaim(c => c.Type == AppConstants.RoleClaimType && c.Value == role))
            //{
            //    identity.AddClaim(new Claim(AppConstants.RoleClaimType, roleClaimValue));
            //}

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
            var resolvedReturnUrl = TempData["returnUrl"] as string ?? Url.Action("Index", "AllEvents");

            return await Task.FromResult<IActionResult>(Redirect(resolvedReturnUrl!));

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
    
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //#region Helpers


    //Not Done Yet
    //private async Task<List<Facil>> LoadFacilitiesAsync()
    //{
    //    try
    //    {
    //        var plants = await _coreService.GetAllPlants();
    //        return plants
    //            .Select(f => f.FacilNo, f => f.FacilName)
    //            .OrderBy(f => f.Name)
    //            .ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Failed to load facilities, using fallback.");
    //        return [new Facil(1, "Fallback A"), new FacilityOption(2, "Fallback B")];
    //    }
    //}

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
