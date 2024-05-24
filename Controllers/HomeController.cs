using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;

// Define the namespace for the controllers
namespace SalesWebMvc.Controllers
{
    /// <summary>
    /// HomeController class that inherits from the Controller base class.
    /// </summary>
    public class HomeController : Controller
    {
        // Private field for the logger
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor for the HomeController.
        /// </summary>
        /// <param name="logger">An instance of ILogger<HomeController>.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles requests to the home page (../Home/Index).
        /// </summary>
        /// <returns>The view associated with this action.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handles requests to the privacy page (../Home/Privacy).
        /// </summary>
        /// <returns>The view associated with this action.</returns>
        public IActionResult Privacy()
        {
            ViewData["Message"] = "Your privacy is important to us, we will not share your information with anyone.";
            ViewData["Email"] = "e-Mail us at: evertondavid@outlook.com";
            return View();
        }

        /// <summary>
        /// Handles requests to the error page (../Home/Error).
        /// </summary>
        /// <returns>The view associated with this action, passing in a new ErrorViewModel.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
