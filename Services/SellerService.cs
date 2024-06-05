using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    /// <summary>
    /// This class provides services related to the Seller entity.
    /// </summary>
    public class SellerService
    {
        // Database context instance
        private readonly SalesWebMvcDbContext _context;

        /// <summary>
        /// Constructor that receives the database context instance via dependency injection.
        /// </summary>
        /// <param name="context">The database context instance.</param>
        public SellerService(SalesWebMvcDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method retrieves all sellers from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of Seller objects.</returns>
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        /// <summary>
        /// This method inserts a new seller into the database.
        /// </summary>
        /// <param name="obj">The Seller object to insert.</param>
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This method retrieves a seller by its ID.
        /// </summary>
        /// <param name="id">The ID of the seller to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Seller object, or null if no seller is found with the given ID.</returns>
        public async Task<Seller?> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        /// <summary>
        /// This method removes a seller from the database.
        /// </summary>
        /// <param name="id">The ID of the seller to remove.</param>
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                if (obj == null)
                {
                    throw new NotFoundException("Seller not found");
                }
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) // This exception is thrown when there is a concurrency error in the level of database.
            {
                throw new IntegrityException("Can't delete seller because he/she has sales: System message(" + e.Message + ")"); // We throw our custom exception at Service Level.
            }
        }

        /// <summary>
        /// This method updates a seller in the database.
        /// </summary>
        /// <param name="obj">The Seller object to update.</param>
        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) // This exception is thrown when there is a concurrency error in the level of database.
            {
                throw new DbConcurrencyException(e.Message); // We throw our custom exception at Service Level.
            }
        }
    }
}
