using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() // ../Home/Index
    {
        return View();
    }
    public IActionResult Privacy() // ../Home/Privacy
    {
        ViewData["Message"] = "Your privacy is important to us, we will not share your information with anyone.";
        ViewData["Email"] = "e-Mail us at: evertondavid@outlook.com";
        return View();

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() // ../Home/Error
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
