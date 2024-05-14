using Microsoft.AspNetCore.Mvc;

namespace Senac.Medilink.Controllers
{
    public class ScheduleController : Controller
    {
        public async Task<IActionResult> OnlineSchedule()
        {
            return View();
        }

        public async Task<IActionResult> PresentialSchedule()
        {
            return View();
        }
    }
}
