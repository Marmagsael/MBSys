using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MBApps.Controllers
{
    [Authorize]
    public class SampleController : Controller
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        // GET: /Sample/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
