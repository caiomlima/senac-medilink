using Microsoft.AspNetCore.Mvc;
using Senac.Medilink.Common;
using Senac.Medilink.Data.Dto.Request;
using Senac.Medilink.Data.Dto.Result;
using Senac.Medilink.Services;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Controllers
{
    public class PatientPresentialAppointmentController : Controller
    {
        private readonly ISpecialtyService _specialtyService;
        private readonly IUnitService _unitService;
        private readonly IProfessionalService _professionalService;
        private readonly IScheduleService _scheduleService;
        private readonly TokenService _tokenService;

        public PatientPresentialAppointmentController(
            ISpecialtyService specialtyService,
            IUnitService unitService,
            IProfessionalService professionalService,
            IScheduleService scheduleService,
            TokenService tokenService)
        {
            _specialtyService = specialtyService;
            _unitService = unitService;
            _professionalService = professionalService;
            _scheduleService = scheduleService;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var specialties = await _specialtyService.GetAllAsync(ServiceType.Appointment, cancellationToken);

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
            var unities = await _unitService.GetAllAsync(cancellationToken);

            return View(unities);
        }

        [HttpPost]
        public IActionResult Unities(long unitId, string unitName, string unitDescription, CancellationToken cancellationToken)
        {
            TempData["UnitId"] = unitId.ToString();
            TempData["UnitName"] = unitName;
            TempData["UnitDescription"] = unitDescription ?? "";

            return RedirectToAction("Professionals");
        }

        public async Task<IActionResult> Professionals(CancellationToken cancellationToken)
        {
            var request = new ProfessionalsForSchedulingRequest
            {
                SpecialtyId = long.Parse(TempData["SpecialtyId"].ToString()),
                UnitId = long.Parse(TempData["UnitId"].ToString()),
                FormOfService = Common.FormOfService.Presential
            };

            var professionals = await _professionalService.GetForSchedulingAsync(request, cancellationToken);

            TempData["SpecialtyId"] = request.SpecialtyId.ToString();
            TempData["UnitId"] = request.UnitId.ToString();

            return View(professionals);
        }

        [HttpPost]
        public IActionResult Professionals(long professionalId, string professionalName, CancellationToken cancellationToken)
        {
            TempData["ProfessionalId"] = professionalId.ToString();
            TempData["ProfessionalName"] = professionalName;

            return RedirectToAction("ProfessionalWorkSchedules");
        }

        public async Task<IActionResult> ProfessionalWorkSchedules(CancellationToken cancellationToken)
        {
            var professisonalId = long.Parse(TempData["ProfessionalId"].ToString());
            var unitId = long.Parse(TempData["UnitId"].ToString());
            var workSchedules = await _scheduleService.GetAvailableSlotsOfProfessionalForSchedulingAsync(professisonalId, unitId, DateTime.Now, cancellationToken: cancellationToken);

            TempData["ProfessionalId"] = professisonalId.ToString();
            TempData["UnitId"] = unitId.ToString();

            return View(workSchedules);
        }

        [HttpPost]
        public IActionResult ProfessionalWorkSchedules(DateOnly day, TimeSpan startTime, CancellationToken cancellationToken)
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
                Type = ServiceType.Appointment,
                SpecialtyId = long.Parse(TempData["SpecialtyId"].ToString()),
                SpecialtyName = TempData["SpecialtyName"].ToString(),
                ProfessionalId = long.Parse(TempData["ProfessionalId"].ToString()),
                ProfessionalName = TempData["ProfessionalName"].ToString(),
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
                request.ServiceType = ServiceType.Appointment;

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
    }
}
