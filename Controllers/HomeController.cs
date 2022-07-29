using System.Diagnostics;
using DashmixMockups.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DashmixMockups.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController (ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {

            if(User.IsInRole("Stelexos"))
                return RedirectToAction("Stelexos");

            if (User.IsInRole("User"))
                return RedirectToAction("Client");

            return View();
        }

        public IActionResult Stelexos() {
            return View();
        }

        public IActionResult Client()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}