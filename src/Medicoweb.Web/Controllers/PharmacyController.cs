using Medicoweb.Drug.Contracts;
using Medicoweb.Pharmacy.Contracts;
using Medicoweb.Web.ViewModels;
using Medicoweb.Web.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Medicoweb.Web.Controllers
{
    public class PharmacyController : MedicowebBaseController
    {
        private readonly IPharmacyService _pharmacyService;
        private readonly IDrugService _drugService;


        public PharmacyController(IPharmacyService pharmacyService, IDrugService drugService)
        {
            _pharmacyService = pharmacyService;
            _drugService = drugService;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> CreatePharmacy([FromBody] CreatePharmacyRequestViewModel request)
        {
            var model = await _pharmacyService.CreatePharmacy(request.Name, request.Address);
            var result = new PharmacyViewModel(model);
            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task AddDrugToPharmacy([FromBody] AddDrugToPharmacyViewModel request)
        {
            var pharmacy = await _pharmacyService.GetPharmacyById(request.PharmacyId);
            var drug = await _drugService.GetDrugById(request.DrugId);
            await _pharmacyService.AddDrugToPharmacy(pharmacy, drug);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task UpdatePharmacy([FromBody] UpdatePharmacyRequestViewModel request)
        {
            await _pharmacyService.UpdatePharmacyAsync(request.Id, request.Name, request.Address);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public JsonResult GetPharmacies([FromQuery] int page, [FromQuery] int postsPerPage = 10)
        {
            var model = _pharmacyService.GetPharmacies(page, postsPerPage);
            var result = new PharmacyListViewModel(model);
            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<JsonResult> GetDrugsFromPharmacy([FromQuery] string pharmacyId, [FromQuery] int page, [FromQuery] int postsPerPage = 10)
        {
            var pharmacy = await _pharmacyService.GetPharmacyById(pharmacyId);
            var model = _drugService.GetDrugsFromPharmacy(pharmacy);
            var result = new DrugPharmacyListViewModel(model);
            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task DeleteDrugFromPharmacy([FromQuery] string drugId, [FromQuery] string pharmacyId)
        {
            var pharmacy = await _pharmacyService.GetPharmacyById(pharmacyId);
            var drug = await _drugService.GetDrugById(drugId);
            await _drugService.RemoveDrugFromPharmacy(pharmacy, drug);

        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task DeletePharmacy([FromQuery] string pharmacyId)
        {
            await _pharmacyService.DeletePharmacy(pharmacyId);
        }
    }
}
