using MBApiLibrary.DataAccess._11_AMS;
using MBApps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MBApps.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IAMSTableMaker _tblMaker; 

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IAMSTableMaker tblMaker)
        {
            _logger     = logger;
            _config     = config;
            _tblMaker   = tblMaker;
        }

        public async Task<IActionResult> Index()
        {
            await CreateTable();

            bool isCommercial = _config.GetSection("CompanyInfo:CommercialUse").Value == "true";
            if (isCommercial)   return View("Marketing");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private async Task CreateTable()
        {
            var pisDb = User.Claims.Where(c => c.Type == "SchemaUserPis")?.FirstOrDefault();
            if (string.IsNullOrEmpty(pisDb?.Value)) return;

            var connName = User.Claims.Where(c => c.Type == "Conn")?.FirstOrDefault();
            if (string.IsNullOrEmpty(connName?.Value)) return;

            await _tblMaker._01AMSTable(pisDb.Value??"", connName.Value??"");

            Console.WriteLine($"Creating table for PIS DB: {pisDb.Value}, Connection: {connName.Value}"); 

        }
    }
}
