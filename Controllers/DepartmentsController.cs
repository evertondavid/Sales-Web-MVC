using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Data;

// Define the namespace for the controllers
namespace SalesWebMvc.Controllers
{
    // DepartmentsController class that inherits from the Controller base class
    public class DepartmentsController : Controller
    {
        // Private field for the database context
        private readonly SalesWebMvcDbContext _context;

        /// <summary>
        /// Constructor for the DepartmentsController.
        /// </summary>
        /// <param name="context">An instance of SalesWebMvcDbContext.</param>
        public DepartmentsController(SalesWebMvcDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        /// <summary>
        /// Handles requests to the departments index page (../Departments/Index).
        /// </summary>
        /// <returns>The view associated with this action.</returns>
        public async Task<IActionResult> Index()
        {
            return _context.Department != null ?
                        View(await _context.Department.ToListAsync()) :
                        Problem("Entity set 'SalesWebMvcDbContext.Department'  is null.");
        }

        // GET: Departments/Details/5
        /// <summary>
        /// Handles requests to the departments details page (../Departments/Details/5).
        /// </summary>
        /// <param name="id">The ID of the department.</param>
        /// <returns>The view associated with this action.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        /// <summary>
        /// Handles requests to the departments create page (../Departments/Create).
        /// </summary>
        /// <returns>The view associated with this action.</returns>
        public IActionResult Create()
        {
            return View();
        }


        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Handles POST requests to create a new department (../Departments/Create).
        /// </summary>
        /// <param name="department">The department to be created.</param>
        /// <returns>The view associated with this action.</returns>
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        /// <summary>
        /// Handles GET requests to edit a department (../Departments/Edit/5).
        /// </summary>
        /// <param name="id">The ID of the department to be edited.</param>
        /// <returns>The view associated with this action.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Handles POST requests to edit a department (../Departments/Edit/5).
        /// </summary>
        /// <param name="id">The ID of the department to be edited.</param>
        /// <param name="department">The edited department.</param>
        /// <returns>The view associated with this action.</returns>
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        // GET: Departments/Delete/5
        /// <summary>
        /// Handles GET requests to delete a department (../Departments/Delete/5).
        /// </summary>
        /// <param name="id">The ID of the department to be deleted.</param>
        /// <returns>The view associated with this action.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Department == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Handles POST requests to confirm deletion of a department (../Departments/Delete/5).
        /// </summary>
        /// <param name="id">The ID of the department to be deleted.</param>
        /// <returns>The view associated with this action.</returns>
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Department == null)
            {
                return Problem("Entity set 'SalesWebMvcDbContext.Department'  is null.");
            }
            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if a department exists.
        /// </summary>
        /// <param name="id">The ID of the department.</param>
        /// <returns>True if the department exists, false otherwise.</returns>
        private bool DepartmentExists(int id)
        {
            return (_context.Department?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
