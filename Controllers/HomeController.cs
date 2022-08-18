using System.Diagnostics;
using System.Linq;
using DashmixMockups.Factories;
using DashmixMockups.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DashmixMockups.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        #region Fields

        private readonly ILogger<HomeController> _logger;

        #endregion

        #region Ctor

        public HomeController (ILogger<HomeController> logger) {
            _logger = logger;
        }

        #endregion

        #region Methods

        public IActionResult Index() {
            if (User.IsInRole("Stelexos"))
                return RedirectToAction("Stelexos");

            if (User.IsInRole("User"))
                return RedirectToAction("Client");

            return View();
        }

        public IActionResult Stelexos() {
            var tickets = FakeTicketFactory.GetSomeTickets(50);
            var sortedList = tickets.OrderByDescending(x => x.TicketDate).ToList();
            return View(sortedList);
        }

        public IActionResult Client() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        #endregion
    }
}