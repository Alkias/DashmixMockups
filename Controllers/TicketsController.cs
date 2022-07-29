using DashmixMockups.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DashmixMockups.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        public IActionResult Details (int id) {
            var client = TicketExtensions.Clients();

            var product = TicketExtensions.Products();

            var model = TicketExtensions.Tickets(client, product, id).Generate();

            return View(model);
        }
    }
}