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

            var facilNoClaim = User.Claims.FirstOrDefault(c => c.Type == "DefaultFacilNo")?.Value;

            if (facilNoClaim != null)
            {
                _logger.LogInformation("Facility No: " + facilNoClaim);
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

            if (User.IsInRole("ESL_OPERATOR"))
            {
                _logger.LogInformation("User is ESL_OPERATOR");
            }

            return View();
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
