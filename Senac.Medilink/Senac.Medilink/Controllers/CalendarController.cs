using Microsoft.AspNetCore.Mvc;

namespace Senac.Medilink.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
