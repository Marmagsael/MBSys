using Microsoft.AspNetCore.Mvc;

namespace MBApps.Controllers;

[Route("1100")]
public class AMSController : Controller
{
    private const string ViewPath = "~/Applications/AMS/Pages/";

    // GET
    private static readonly Dictionary<int, string> ReportViews = new()
    {
        // Settings 
        [11002]  = "_11002_StdWorkingHoursSchedule",
        [11003]  = "_11003_EmployeeSchedule",
        [11004]  = "_11004_DailyScheduleTemplate",
        [11005]  = "_11005_WeeklyScheduleTemplate",
        [11006]  = "_11006_OtherScheduleAssignment",
        [11007]  = "_11007_AdvanceScheduleAssignment",
        
        
        [11008]  = "_11008_OvertimeSettings",


        // Transaction
        [12002] = "_12002_AttendanceProcessing",
        [12003] = "_12003_OTEntry",
        [12004] = "_12004_OBDirectAssignment",
        [12005] = "_12005_PunchManagement",

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

    // [HttpGet("{reportCode:int}")]
    // public IActionResult Report(int reportCode)
    // {
    //     Console.WriteLine($"ReportCode: {reportCode}");
    //     Console.WriteLine($"Dictionary Count: {ReportViews.Count}");
    //     Console.WriteLine($"Contains 11002: {ReportViews.ContainsKey(11002)}");

    //     foreach (var item in ReportViews)
    //     {
    //         Console.WriteLine($"{item.Key} => {item.Value}");
    //     }

    //     if (!ReportViews.TryGetValue(reportCode, out var viewName))
    //     {
    //         return NotFound($"Report code '{reportCode}' was not found.");
    //     }

    //     return View($"{ViewPath}{viewName}.cshtml");
    // }


}