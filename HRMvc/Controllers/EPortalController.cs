using Microsoft.AspNetCore.Mvc;
namespace HRMvc.Controllers;

[Route("12")]
public class EPortalController : Controller
{
    private const string ViewPath = "~/Applications/EPortal/Pages/";

    private static readonly Dictionary<int, string> ReportViews = new()
    {
        // --- 
        [102] = "_12_102_Dashboard",
    };


    [HttpGet("{moduleCode:int}")]
    public IActionResult Module(int moduleCode)
    {
        if (!ReportViews.TryGetValue(moduleCode, out var viewName))
        {
            return NotFound($"Module code '{moduleCode}' was not found.");
        }

        return View($"{ViewPath}{viewName}.cshtml");
    }

}