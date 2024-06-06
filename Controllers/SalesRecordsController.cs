// Define the namespace for the controllers
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SalesRecordsController : Controller
{
    private readonly SalesRecordService _salesRecordService;

    public SalesRecordsController(SalesRecordService salesRecordService)
    {
        _salesRecordService = salesRecordService;
    }

    // GET: SalesRecords
    public IActionResult Index()
    {
        return View();
    }
    // GET: SalesRecords/SimpleSearch
    public async Task<ActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
    {
        if (!minDate.HasValue)
        {
            minDate = new DateTime(DateTime.Now.Year, 1, 1);
        }
        if (!maxDate.HasValue)
        {
            maxDate = DateTime.Now;
        }
        ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
        ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
        var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
        return View(result);
    }
    // GET: SalesRecords/GroupingSearch
    public async Task<ActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
    {
        if (!minDate.HasValue)
        {
            minDate = new DateTime(DateTime.Now.Year, 1, 1);
        }
        if (!maxDate.HasValue)
        {
            maxDate = DateTime.Now;
        }
        ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
        ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
        var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
        return View(result);
    }
}
