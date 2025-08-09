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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ISession session = HttpContext.Session;

            //ClaimsPrincipal user = HttpContext.User;

            foreach (Claim claim in User.Claims)
            {
                _logger.LogInformation("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
            }

            var facilNoClaim = User.Claims.FirstOrDefault(c => c.Type == "FacilNo")?.Value;  //claims?. FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value.

            if (User.HasClaim(c => c.Type == "FacilNo"))
            {
                _logger.LogInformation("FACIL NO CLAIM: " + facilNoClaim);
            }

            if (User.IsInRole("Viewer"))
            {
                _logger.LogInformation("User is Viewer");
            }

            

            return View();
        }

        public IActionResult Privacy()
        {
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
