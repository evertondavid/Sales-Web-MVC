using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    // This class provides services related to the Seller entity.
    public class SellerService
    {
        // Database context instance
        private readonly SalesWebMvcDbContext _context;

        // Constructor that receives the database context instance via dependency injection
        // <param name="context">The database context instance.</param>
        public SellerService(SalesWebMvcDbContext context)
        {
            _context = context;
        }

        // This method retrieves all sellers from the database.
        // <returns>A list of Seller objects.</returns>
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        // This method inserts a new seller into the database.
        // <param name="obj">The Seller object to insert.</param>
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        // This method retrieves a seller by its ID.
        // <param name="id">The ID of the seller to retrieve.</param>
        // <returns>A Seller object, or null if no seller is found with the given ID.</returns>
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        // This method removes a seller from the database.
        // <param name="id">The ID of the seller to remove.</param>
        public void Remove(int id)
        {
            try
            {
                var obj = _context.Seller.Find(id);
                _context.Seller.Remove(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) // This exception is thrown when there is a concurrency error in the level of database.
            {
                throw new DbConcurrencyException(e.Message); // We throw our custom exception at Service Level.
            }
        }

        // This method updates a seller in the database.
        // <param name="obj">The Seller object to update.</param>
        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) // This exception is thrown when there is a concurrency error in the level of database.
            {
                throw new DbConcurrencyException(e.Message); // We throw our custom exception at Service Level.
            }
        }
    }
}
