using Medicoweb.Drug.Contracts;
using Medicoweb.Visit.Contracts;
using Medicoweb.Web.ViewModels;
using Medicoweb.Web.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace Medicoweb.Web.Controllers
{
    public class DrugController : MedicowebBaseController
    {
        private readonly IDrugService _drugService;
        private readonly IPrescriptionService _prescriptionService;


        public DrugController(IDrugService drugService, IPrescriptionService prescriptionService)
        {
            _drugService = drugService;
             _prescriptionService = prescriptionService;
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateDrug([FromBody] CreateDrugRequestViewModel request)
        {
            var model = await _drugService.CreateDrugAsync(request.Name, request.Company);
            var result = new DrugViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpDelete]
        public async Task DeleteDrug([FromQuery] string id)
        {
            await _drugService.DeleteDrug(id);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetDrugs([FromQuery] int page, [FromQuery] int threadsPerPage = 10)
        {
            var model = _drugService.GetDrugs(page, threadsPerPage);
            var result = new DrugListViewModel(model);
            return Json(result);
        }

        [HttpPut]
        public async Task UpdateDrug([FromBody] UpdateDrugRequestViewModel request)
        {
            await _drugService.UpdateDrug(request.Id, request.Name, request.Company);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> AddDrugToPrescription([FromQuery] AddDrugToPrescriptionRequestViewModel request)
        {
            var prescription = await _prescriptionService .GetPrescriptionById(request.PrescriptionId);
            var drug = await _drugService.GetDrugById(request.DrugId);
            var model = await _drugService.AddDrugToPrescriptionAsync(prescription, drug, request.QuantityDrug);
            var result = new DrugsFromPrescriptionViewModel(model); //czy działa?

            return Json(result);
        }

    }
}
