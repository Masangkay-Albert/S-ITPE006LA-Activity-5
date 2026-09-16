using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EnterpriseStore.Web.Models;

namespace EnterpriseStore.Web.Controllers;

// Constrain this controller to the "/enterprise" path to avoid colliding
// with the app's default HomeController (S_ITPE006LA___Activity_5.Controllers.HomeController).
[Route("enterprise")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Matches: /enterprise and /enterprise/Index
    [HttpGet("")]
    [HttpGet("Index")]
    public IActionResult Index()
    {
        // Use the shared view so the UI shows the expected "Welcome" page.
        return View("~/Views/Home/Index.cshtml");
    }

    // Matches: /enterprise/Privacy
    [HttpGet("Privacy")]
    public IActionResult Privacy()
    {
        return View("~/Views/Home/Privacy.cshtml");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet("Error")]
    public IActionResult Error()
    {
        return View("~/Views/Home/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
