using System;
using System.Threading.Tasks;
using Medicoweb.Drug.Contracts;
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
        private readonly IDrugService _drugService;

        public VisitController(IVisitService visitService, IHospitalService hospitalService, IPrescriptionService prescriptionService, IDrugService drugService)
        {
            _visitService = visitService;
            _hospitalService = hospitalService;
            _prescriptionService = prescriptionService;
            _drugService = drugService;
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateVisit([FromBody] CreateVisitRequestViewModel request)
        {
            var doctor = await _hospitalService.GetDoctorById(request.DoctorId);
            var patient = await _hospitalService.GetPatientById(request.PatientId);
            DateTime enteredDate = DateTime.Parse(request.Date);
            var hospital = await _hospitalService.GetHospital(request.HospitalId);
            var visit = await _visitService.CreateVisit(patient, doctor, enteredDate, hospital);

            var result = new VisitViewModel(visit);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetPatientVisits([FromQuery] string id)
        {
            var model = await _visitService.GetPatientVisits(id);
            var result = new VisitListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDoctorVisits([FromQuery] string id)
        {
            var model = await _visitService.GetDoctorVisits(id);
            var result = new VisitListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetHoursFromDay([FromQuery] string date)
        {
            DateTime enteredDate = DateTime.Parse(date);
            var hours = _visitService.GetHoursFromDay(enteredDate);
            return Json(hours);
        }


        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreatePrescription([FromBody]  CreatePrescriptionRequestViewModel request) //ok
        {
            var visit = await _visitService.GetVisitById(request.VisitId);
            var model = await _prescriptionService.CreatePrescriptionAsync(visit);
            var result = new PrescriptionViewModel(model);
            return Json(result);
           
        }


        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDrugsFromPrescripion([FromQuery] string perscriptionId)
        {
            var prescription = await _prescriptionService.GetPrescriptionById(perscriptionId);
            var model = await _prescriptionService.GetDrugsFromPrescription(prescription); //drugListing
            var result = new DrugsFromPrescriptionListingViewModel(model); ///ok??
            return Json(result);

        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetPatientPrescriptions([FromQuery] string patientId)
        {
            var model = await _prescriptionService.GetPatientPrescriptions(patientId);
            var result = new PrescriptionListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetPrescriptionsFromVisit([FromQuery] string visitId)//ok
        {
            var visit = await _visitService.GetVisitById(visitId);
            var model = _prescriptionService.GetPrescriptionsFromVisit(visit);
            var result = new PrescriptionListingViewModel(model);
            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task AddDrugToPrescription([FromBody] AddDrugToPrescriptionRequestViewModel request)
        {
            var drug =  await _drugService.GetDrugById(request.DrugId);
            await _prescriptionService.AddDrugToPrescription(request.PrescriptionId, drug, request.DrugQuantity);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetPrescription([FromQuery] string prescriptionId)
        {
            var model =  await _prescriptionService.GetPrescriptionById(prescriptionId);
            var result = new PrescriptionViewModel(model);
            return Json(result);
        }
        

    }
}