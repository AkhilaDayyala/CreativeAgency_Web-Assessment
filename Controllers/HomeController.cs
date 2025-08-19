using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.CreativeAgency.Models;

namespace Web.CreativeAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index() => View();

        [Route("about")] public IActionResult About() => View();
        [Route("services")] public IActionResult Services() => View();
    }
}
