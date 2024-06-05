using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    /// <summary>
    /// This class provides services related to the Department entity.
    /// </summary>
    public class DepartmentService
    {
        // Database context instance
        private readonly SalesWebMvcDbContext _context;

        /// <summary>
        /// Constructor that receives the database context instance via dependency injection.
        /// </summary>
        /// <param name="context">The database context instance.</param>
        public DepartmentService(SalesWebMvcDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method retrieves all departments from the database and orders them by name.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of Department objects.</returns>
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); // Retrieve all departments from the database and order them by name
        }
    }
}
