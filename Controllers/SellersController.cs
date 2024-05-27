using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    //[Route("[controller]")]
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Returns a 404 Not Found status code
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound(); // Returns a 404 Not Found status code
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Returns a 404 Not Found status code
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound(); // Returns a 404 Not Found status code
            }

            return View(obj);
        }

        [HttpPost] // This attribute indicates that the method responds to HTTP POST requests
        [ValidateAntiForgeryToken] // This attribute helps prevent CSRF attacks (Cross-Site Request Forgery) by validating the request token
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
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
