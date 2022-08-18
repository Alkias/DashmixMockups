using Microsoft.AspNetCore.Mvc;

namespace DashmixMockups.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}