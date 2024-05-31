using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Senac.Medilink.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> ExamSchedule()
        {
            return View();
        }
        public async Task<IActionResult> _UnitLayout()
        {
            return View();
        }
        public async Task<IActionResult> Agenda()
        {
            return View();
        }

    }
}
