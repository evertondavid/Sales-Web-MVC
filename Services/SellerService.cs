using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Linq;

namespace SalesWebMvc.Services
{
    // This class provides services related to the Seller entity.
    public class SellerService
    {
        // Database context instance
        private readonly SalesWebMvcDbContext _context;

        // Constructor that receives the database context instance via dependency injection
        public SellerService(SalesWebMvcDbContext context)
        {
            _context = context;
        }

        // This method retrieves all sellers from the database.
        // It returns a list of Seller objects.
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        // This method inserts a new seller into the database.
        // It receives a Seller object as argument.
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        // This method retrieves a seller by its ID.
        // It receives an integer ID as argument.
        // It returns a Seller object.
        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        // This method removes a seller from the database.
        // It receives an integer ID as argument.
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
