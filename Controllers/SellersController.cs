using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;
using System.Diagnostics;
namespace SalesWebMvc.Controllers
{
    // The SellersController class is a controller for the Seller entity.
    // It handles HTTP requests and responses for actions related to sellers.
    public class SellersController : Controller
    {
        // These fields hold instances of the SellerService and DepartmentService classes.
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        // Constructor that receives instances of SellerService and DepartmentService via dependency injection.
        // <param name="sellerService">The service for Seller-related actions.</param>
        // <param name="departmentService">The service for Department-related actions.</param>
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        // This method handles the HTTP GET request for the Index view.
        // It retrieves all sellers from the database and returns them to the view.
        // <returns>A view with a list of all sellers.</returns>
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        // This method handles the HTTP GET request for the Create view.
        // It retrieves all departments from the database and returns them to the view.
        // <returns>A view with a ViewModel containing a list of all departments.</returns>
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        // This method handles the HTTP GET request for the Details view.
        // It retrieves a seller by ID from the database and returns it to the view.
        // If the ID is null or the seller is not found, it returns a 404 Not Found status code.
        // <param name="id">The ID of the seller to retrieve.</param>
        // <returns>A view with the details of the seller, or a 404 Not Found status code if the seller is not found.</returns>
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provide" }); // Redirects to the Error action method of this controller
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); // Redirects to the Error action method of this controller
            }

            return View(obj);
        }

        // This method handles the HTTP GET request for the Delete view.
        // It retrieves a seller by ID from the database and returns it to the view.
        // If the ID is null or the seller is not found, it returns a 404 Not Found status code.
        // <param name="id">The ID of the seller to delete.</param>
        // <returns>A view with the seller to delete, or a 404 Not Found status code if the seller is not found.</returns>
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provide" }); // Redirects to the Error action method of this controller
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); // Redirects to the Error action method of this controller
            }

            return View(obj);
        }

        [HttpPost] // This attribute indicates that the method responds to HTTP POST requests
        [ValidateAntiForgeryToken] // This attribute helps prevent CSRF attacks (Cross-Site Request Forgery) by validating the request token
        // This method handles the HTTP POST request for deleting a seller.
        // It calls the service layer to remove the seller from the database and then redirects to the Index action method.
        // <param name="id">The ID of the seller to delete.</param>
        // <returns>A redirection to the Index action method.</returns>
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost] // This attribute indicates that the method responds to HTTP POST requests
        [ValidateAntiForgeryToken] // This attribute helps prevent CSRF attacks (Cross-Site Request Forgery) by validating the request token
        // This method handles the HTTP POST request for creating a new seller.
        // It calls the service layer to insert the new seller into the database and then redirects to the Index action method.
        // <param name="seller">The seller to create.</param>
        // <returns>A redirection to the Index action method.</returns>
        public IActionResult Create(Seller seller)
        {
            // If the model state is not valid, it returns the view with the seller and a list of departments
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            _sellerService.Insert(seller); // Calls the service layer to insert the new seller into the database
            return RedirectToAction(nameof(Index)); // Redirects to the Index action method of this controller
        }

        // This method handles the HTTP GET request for the Edit view.
        // It retrieves a seller by ID and all departments from the database and returns them to the view.
        // If the ID is null or the seller is not found, it returns a 404 Not Found status code.
        // <param name="id">The ID of the seller to edit.</param>
        // <returns>A view with the seller to edit and a list of all departments, or a 404 Not Found status code if the seller is not found.</returns>
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provide" }); // Redirects to the Error action method of this controller
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" }); // Redirects to the Error action method of this controller
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost] // This attribute indicates that the method responds to HTTP POST requests
        [ValidateAntiForgeryToken] // This attribute helps prevent CSRF attacks (Cross-Site Request Forgery) by validating the request token
        // This method handles the HTTP POST request for updating a seller.
        // It calls the service layer to update the seller in the database and then redirects to the Index action method.
        // If the ID does not match the seller's ID, it returns a 400 Bad Request status code.
        // If an exception is thrown when updating the seller, it returns a 404 Not Found or 400 Bad Request status code.
        // <param name="id">The ID of the seller to update.</param>
        // <param name="seller">The seller to update.</param>
        // <returns>A redirection to the Index action method, or a 404 Not Found or 400 Bad Request status code if an error occurs.</returns>
        public IActionResult Edit(int id, Seller seller)
        {
            // If the model state is not valid, it returns the view with the seller and a list of departments
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id missmatch" }); // Redirects to the Error action method of this controller
            }

            try
            {
                _sellerService.Update(seller); // Calls the service layer to update the seller in the database
                return RedirectToAction(nameof(Index)); // Redirects to the Index action method of this controller
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); // Redirects to the Error action method of this controller
            }
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
