using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBD.HOSPITAL.Contracts;
using SBD.VISIT.Contracts;
using SBD.WEB.ViewModels;
using SBD.WEB.ViewModels.Request;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SBD.WEB.Controllers
{
    public class VisitController : SBDBaseController
    {
        private readonly IVisitService _visitService;
        private readonly IHospitalService _hospitalService;

        public VisitController(IVisitService visitService, IHospitalService hospitalService)
        {
            _visitService = visitService;
            _hospitalService = hospitalService;
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateVisit([FromQuery] CreateVisitRequestViewModel request)
        {
            var doctor = await  _hospitalService.GetDoctorById(request.DoctorId);
            var patient = await  _hospitalService.GetPatientById(request.SBDUserId);
            var visitTime =  await _visitService.CreateVisitTime(request.VisitStart);
            var visit = await _visitService.CreateVisit(patient,doctor,visitTime);

            var result = new VisitViewModel(visit);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetPatientVisits ([FromBody] string patientId, [FromQuery] int page, [FromQuery] int threadsPerPage = 10)
        {
            var model = await _visitService.GetPtientVisits(patientId, page, threadsPerPage);
            var result = new VisitListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDoctorVisits([FromBody] string doctorId, [FromQuery] int page, [FromQuery] int threadsPerPage = 10)
        {
            var model = await _visitService.GetDoctorVisits(doctorId, page, threadsPerPage);
            var result = new VisitListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpPut]
        public async Task UpdateVisitAsync ([FromBody] string id)
        {
            var model = await _visitService.GetVisitById(id);
            _visitService.UpdateVisit(model);
        }

        //do anulacji vizyty
    }
}
