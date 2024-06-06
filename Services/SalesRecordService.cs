using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
namespace SalesWebMvc.Services;

public class SalesRecordService
{
    // Database context instance
    private readonly SalesWebMvcDbContext _context;

    /// <summary>
    /// Constructor that receives the database context instance via dependency injection.
    /// </summary>
    /// <param name="context">The database context instance.</param>
    public SalesRecordService(SalesWebMvcDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// This method retrieves all sales records from the database and orders them by date.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of SalesRecord objects.</returns>
    public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        var result = from obj in _context.SalesRecord select obj;
        if (minDate.HasValue)
        {
            result = result.Where(x => x.Date >= minDate.Value);
        }
        if (maxDate.HasValue)
        {
            result = result.Where(x => x.Date <= maxDate.Value);
        }
        return await result
            //.Where(x => x.Seller != null && x.Seller.Department != null)
            .Include(x => x.Seller)
            .Include(x => x.Seller.Department)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
    }

    /// <summary>
    /// This method retrieves all sales records from the database and orders them by date.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of SalesRecord objects.</returns>
    public async Task<List<IGrouping<Department?, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
    {
        var result = from obj in _context.SalesRecord select obj;
        if (minDate.HasValue)
        {
            result = result.Where(x => x.Date >= minDate.Value);
        }
        if (maxDate.HasValue)
        {
            result = result.Where(x => x.Date <= maxDate.Value);
        }
        return await result
            //.Where(x => x.Seller != null && x.Seller.Department != null)
            .Include(x => x.Seller)
            .Include(x => x.Seller.Department)
            .OrderByDescending(x => x.Date)
            .GroupBy(x => x.Seller.Department)
            .ToListAsync();
    }

}
