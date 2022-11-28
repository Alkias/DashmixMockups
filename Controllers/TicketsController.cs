using System.Linq;
using DashmixMockups.Data;
using DashmixMockups.Data.Tickets;
using DashmixMockups.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DashmixMockups.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        #region Methods

        public IActionResult Details (int id) {
            var model = FakeTicketFactory.GetSomeTickets(1).FirstOrDefault();
            model.Id = id;

            return View(model);
        }

        public IActionResult Create() {
            var model = new Ticket();
            return View(model);
        }

        #endregion
    }
}