using Microsoft.AspNetCore.Mvc;

namespace MBApps.Controllers;

[Route("1000")]
public class MenusController : Controller
{
    private const string ViewPath = "~/Applications/Menus/Pages/";

    // GET
    private static readonly Dictionary<int, string> ReportViews = new()
    {
        // Settings 
        [1000]  = "_1000_Menus",
    };

    [HttpGet("{reportCode:int}")]
    public IActionResult Report(int reportCode)
    {
        if (!ReportViews.TryGetValue(reportCode, out var viewName))
        {
            return NotFound($"Report code '{reportCode}' was not found.");
        }

        return View($"{ViewPath}{viewName}.cshtml");
    }

 

}