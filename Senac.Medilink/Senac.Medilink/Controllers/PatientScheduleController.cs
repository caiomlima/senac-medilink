using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Controllers;

[Authorize]
public class PatientScheduleController : Controller
{
    private readonly IScheduleService _scheduleService;

    public PatientScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var userIdClaim = User.Claims.FirstOrDefault(claim => claim.Type == "id");
        if (userIdClaim == null)
            return RedirectToAction("Index", "Auth");

        var schedules = await _scheduleService.GetSchedulesOfPatientAsync(long.Parse(userIdClaim.Value), cancellationToken);

        return View(schedules);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long scheduleId, CancellationToken cancellationToken)
    {
        try
        {
            await _scheduleService.DeleteAsync(scheduleId, cancellationToken);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            RedirectToAction("Index");
            return ViewBag(ex.Message);
        }
    }
}
