﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBD.HOSPITAL.Contracts;
using SBD.VISIT.Contracts;
using SBD.WEB.ViewModels;
using SBD.WEB.ViewModels.Request;
using System.Threading.Tasks;

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
        public async Task<JsonResult> CreateVisit([FromBody] CreateVisitRequestViewModel request)
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

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateDrug([FromBody] CreateDrugRequestViewModel request)
        {
           var model = await _visitService.CreateDrugAsync(request.Name, request.Company);
           var result = new DrugViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreatePrescription([FromBody] CreatePrescriptionRequestViewModel request)
        {
            var visit = await _visitService.GetVisitById(request.VisitId);
            var model = await _visitService.CreatePrescriptionAsync(visit);
            var result = new PrescriptionViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetPatientPrescriptions([FromBody] string patientId, [FromQuery] int page, [FromQuery] int threadsPerPage = 10)
        {
            var model = await _visitService.GetPatientPrescriptions(patientId, page, threadsPerPage);
            var result = new PrescriptionListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> AddDrugToPrescription([FromQuery] AddDrugToPrescriptionRequestViewModel request)
        {
            var prescription = await _visitService.GetPrescriptionById(request.PrescriptionId);
            var drug = await _visitService.GetVDrugById(request.DrugId);
            var model = await _visitService.AddDrugToPrescriptionAsync(prescription,drug,request.QuantityDrug);
            var result = new DrugsFromPrescriptionViewModel(model); //czy działa?

            return Json(result);
        }
        [Authorize]
        [HttpGet]
        public JsonResult GetDrugs( [FromQuery] int page, [FromQuery] int threadsPerPage = 10)
        {
            var model =  _visitService.GetDrugs(page, threadsPerPage);
            var result = new DrugListViewModel(model);
            return Json(result);
        }

    }
}
