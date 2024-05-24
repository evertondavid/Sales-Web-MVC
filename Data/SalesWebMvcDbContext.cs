using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

// Define the namespace for the data
namespace SalesWebMvc.Data
{
    /// <summary>
    /// Class for SalesWebMvcDbContext.
    /// This class represents the database context for the application.
    /// </summary>
    public class SalesWebMvcDbContext : DbContext
    {
        /// <summary>
        /// Constructor for the SalesWebMvcDbContext class.
        /// </summary>
        /// <param name="options">The options to be used by a DbContext.</param>
        public SalesWebMvcDbContext(DbContextOptions<SalesWebMvcDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet of Departments.
        /// </summary>
        public DbSet<Department> Department { get; set; } = default!;

        /// <summary>
        /// Gets or sets the DbSet of Sellers.
        /// </summary>
        public DbSet<Seller> Seller { get; set; } = default!;

        /// <summary>
        /// Gets or sets the DbSet of SalesRecords.
        /// </summary>
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}
