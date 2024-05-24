using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    //[Route("[controller]")]
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // This attribute indicates that the method responds to HTTP POST requests
        [ValidateAntiForgeryToken] // This attribute helps prevent CSRF attacks (Cross-Site Request Forgery) by validating the request token
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller); // Calls the service layer to insert the new seller into the database
            return RedirectToAction(nameof(Index)); // Redirects to the Index action method of this controller
        }
    }
}
