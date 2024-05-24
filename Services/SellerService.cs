using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

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

    }
}
