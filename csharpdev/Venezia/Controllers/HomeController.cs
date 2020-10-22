using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Venezia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index de HomeController");
            return View();
        }

        [HttpGet]
        [Route("a-propos-de-nous", Name = "RouteAbout")]
        public IActionResult About()
        {
            _logger.LogInformation("Index de HomeController");
            return View();
        }
    }
}
