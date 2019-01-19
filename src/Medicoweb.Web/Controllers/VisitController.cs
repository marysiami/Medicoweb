using System.Threading.Tasks;
using Medicoweb.Hospital.Contracts;
using Medicoweb.Visit.Contracts;
using Medicoweb.Web.ViewModels;
using Medicoweb.Web.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicoweb.Web.Controllers
{
    public class VisitController : MedicowebBaseController
    {
        private readonly IHospitalService _hospitalService;
        private readonly IVisitService _visitService;
        private readonly IPrescriptionService _prescriptionService;

        public VisitController(IVisitService visitService, IHospitalService hospitalService, IPrescriptionService prescriptionService)
        {
            _visitService = visitService;
            _hospitalService = hospitalService;
            _prescriptionService = prescriptionService;
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateVisit([FromBody] CreateVisitRequestViewModel request)
        {
            var doctor = await _hospitalService.GetDoctorById(request.DoctorId);
            var patient = await _hospitalService.GetPatientById(request.SBDUserId);
            var visitTime = await _visitService.CreateVisitTime(request.VisitStart);
            var visit = await _visitService.CreateVisit(patient, doctor, visitTime);

            var result = new VisitViewModel(visit);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetPatientVisits([FromBody] string patientId, [FromQuery] int page,
            [FromQuery] int threadsPerPage = 10)
        {
            var model = await _visitService.GetPatientVisits(patientId, page, threadsPerPage);
            var result = new VisitListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDoctorVisits([FromBody] string doctorId, [FromQuery] int page,
            [FromQuery] int threadsPerPage = 10)
        {
            var model = await _visitService.GetDoctorVisits(doctorId, page, threadsPerPage);
            var result = new VisitListingViewModel(model);

            return Json(result);
        }

        //do anulacji vizyty


        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreatePrescription([FromBody] CreatePrescriptionRequestViewModel request)
        {
            var visit = await _visitService.GetVisitById(request.VisitId);
            var model = await _prescriptionService.CreatePrescriptionAsync(visit);
            var result = new PrescriptionViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetPatientPrescriptions([FromBody] string patientId, [FromQuery] int page,
            [FromQuery] int threadsPerPage = 10)
        {
            var model = await _prescriptionService.GetPatientPrescriptions(patientId, page, threadsPerPage);
            var result = new PrescriptionListingViewModel(model);

            return Json(result);
        }  
    }
}