using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    // This class provides services related to the Seller entity.
    public class DepartmentService
    {
        // Database context instance
        private readonly SalesWebMvcDbContext _context;

        // Constructor that receives the database context instance via dependency injection
        public DepartmentService(SalesWebMvcDbContext context)
        {
            _context = context;
        }

        // This method retrieves all departments from the database.
        // It returns a list of Department objects.
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
