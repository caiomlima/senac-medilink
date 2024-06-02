using Microsoft.AspNetCore.Mvc;
using Senac.Medilink.Common;
using Senac.Medilink.Data.Dto.Request;
using Senac.Medilink.Data.Dto.Result;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Controllers
{
    public class PatientExamController : Controller
    {
        private readonly ISpecialtyService _specialtyService;
        private readonly IUnitService _unitService;
        private readonly IScheduleService _scheduleService;

        public PatientExamController(
            ISpecialtyService specialtyService,
            IUnitService unitService,
            IScheduleService scheduleService)
        {
            _specialtyService = specialtyService;
            _unitService = unitService;
            _scheduleService = scheduleService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var specialties = await _specialtyService.GetAllAsync(ServiceType.Exam, cancellationToken);

            return View(specialties);
        }

        [HttpPost]
        public IActionResult Index(long specialtyId, string specialtyName, CancellationToken cancellationToken)
        {
            TempData["SpecialtyId"] = specialtyId.ToString();
            TempData["SpecialtyName"] = specialtyName;

            return RedirectToAction("Unities");
        }

        public async Task<IActionResult> Unities(CancellationToken cancellationToken)
        {
            var specialtyId = long.Parse(TempData["SpecialtyId"].ToString());
            var unities = await _unitService.GetForSchedulingExamAsync(specialtyId, cancellationToken);

            TempData["SpecialtyId"] = specialtyId.ToString();

            return View(unities);
        }

        [HttpPost]
        public IActionResult Unities(long unitId, string unitName, string unitDescription, CancellationToken cancellationToken)
        {
            TempData["UnitId"] = unitId.ToString();
            TempData["UnitName"] = unitName;
            TempData["UnitDescription"] = unitDescription ?? "";

            return RedirectToAction("UnitWorkSchedules");
        }

        public async Task<IActionResult> UnitWorkSchedules(CancellationToken cancellationToken)
        {
            var unitId = long.Parse(TempData["UnitId"].ToString());
            var specialtyId = long.Parse(TempData["SpecialtyId"].ToString());
            var workSchedules = await _scheduleService.GetAvailableSlotsOfUnitForSchedulingExamAsync(unitId, specialtyId, DateTime.Now, cancellationToken: cancellationToken);

            TempData["SpecialtyId"] = specialtyId.ToString();
            TempData["UnitId"] = unitId.ToString();

            return View(workSchedules);
        }

        [HttpPost]
        public IActionResult UnitWorkSchedules(DateOnly day, TimeSpan startTime, CancellationToken cancellationToken)
        {
            TempData["Date"] = day.ToString();
            TempData["StartTime"] = startTime.ToString();

            return RedirectToAction("Summary");
        }

        public IActionResult Summary()
        {
            var day = DateOnly.Parse(TempData["Date"].ToString());
            var hour = TimeSpan.Parse(TempData["StartTime"].ToString());
            var dateOfSchedule = new DateTime(day.Year, day.Month, day.Day, hour.Hours, hour.Minutes, hour.Seconds);

            var summaryResult = new ScheduleSummary
            {
                FormOfService = FormOfService.Presential,
                Type = ServiceType.Exam,
                SpecialtyId = long.Parse(TempData["SpecialtyId"].ToString()),
                SpecialtyName = TempData["SpecialtyName"].ToString(),
                UnitId = long.Parse(TempData["UnitId"].ToString()),
                UnitName = TempData["UnitName"].ToString(),
                UnitDescription = TempData["UnitDescription"].ToString(),
                Date = dateOfSchedule
            };

            return View(summaryResult);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSchedule(ScheduleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(claim => claim.Type == "id");
                if (userIdClaim == null)
                    return RedirectToAction("Index", "Auth");

                request.PatientId = long.Parse(userIdClaim.Value);
                request.FormOfService = FormOfService.Presential;
                request.ServiceType = ServiceType.Exam;

                await _scheduleService.AddAsync(request);
            }
            catch (Exception ex)
            {
                TempData.Clear();
                RedirectToAction("Index");
                return ViewBag(ex.Message);
            }

            TempData.Clear();

            return RedirectToAction("Concluded");
        }

        public IActionResult Concluded()
        {
            return View();
        }

        public async Task<IActionResult> Results()
        {
            return View();
        }
    }
}
