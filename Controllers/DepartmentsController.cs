using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers
{
    //[Route("[controller]")] mudei agora
    [Route("Departments")]
    public class DepartmentsController : Controller
    {
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(ILogger<DepartmentsController> logger)
        {
            _logger = logger;
        }

        // Map to /Departments or /Departments/Index
        [HttpGet("")]
        [Route("Departments")]
        [Route("Departments/Index")]
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Electronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });

            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        // Map to /Departments/Error
        [HttpGet("Error")]
        [Route("Departments/Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
