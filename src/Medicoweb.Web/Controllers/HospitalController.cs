using System.Threading.Tasks;
using Medicoweb.Account.Contracts;
using Medicoweb.Common.Exceptions;
using Medicoweb.Hospital.Contracts;
using Medicoweb.Web.ViewModels;
using Medicoweb.Web.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicoweb.Web.Controllers
{
    public class HospitalController : MedicowebBaseController
    {
        private readonly IHospitalService _hospitalService;
        private readonly IUserService _userService;


        public HospitalController(
            IHospitalService hospitalService,
            IUserService userService)
        {
            _hospitalService = hospitalService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<JsonResult> GetHospitalsByName([FromQuery] int page, [FromQuery] int threadsPerPage = 10)
        {
            var model = await _hospitalService.GetHospitalsByName(page, threadsPerPage);

            var result = new HospitalListingViewModel(model);

            return Json(result);
        }


        [HttpGet]
        public async Task<JsonResult> GetDepartamentsFromHospital([FromQuery] string hospitalId, [FromQuery] int page,
            [FromQuery] int postsPerPage = 10)
        {
            var hospital = await _hospitalService.GetHospital(hospitalId);

            if (hospital == null) throw new InvalidDepartmanetIdException();

            var model = _hospitalService.GetHospitalDepartaments(hospital, page, postsPerPage);

            var result = new DepartamentListViewModel(model);

            return Json(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> CreateHospital([FromBody] CreateHospitalRequestViewModel request) //dziala
        {
            var test = await _hospitalService.GetHospitalByName(request.Name);
            if (test != null) throw new InvalidCreateHospitalException(); //gdy szpital o takiej samej nazwie istnieje

            var hospital = await _hospitalService.CreateHospital(request.Name, request.Address);
            var result = new HospitalViewModel(hospital);

            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task UpdateHospital([FromBody] UpdateHospitalRequestViewModel request)
        {
            await _hospitalService.UpdateHospital(request.Id, request.Name, request.Address);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task DeleteHospital([FromQuery] string id)
        {
            var model = await _hospitalService.GetHospital(id);
            await _hospitalService.DeleteHospitalAsync(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> CreateDepartament([FromBody] CreateDepartamentRequestViewModel request) //dziala
        {
            var test = await _hospitalService.GetDepartamentByName(request.Name);
            if (test != null)
            {
                if (request.HospitalId == test.HospitalId.ToString())
                    throw new InvalidCreateDepartamentException(); //gdy departament o takiej samej nazwie istnieje
            }

            var hospital = await _hospitalService.GetHospital(request.HospitalId);
            if (hospital == null) throw new InvalidPostThreadIdException();

            var departament = await _hospitalService.CreateDepartamentAsync(request.Name, hospital);
            var result = new DepartamentViewModel(departament);

            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task DeleteDepartament([FromQuery] string id)
        {
            var model = await _hospitalService.GetDepartamentById(id);
            await _hospitalService.DeleteDepartament(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task UpdateDepartament([FromBody] UpdateDepartamentRequestViewModel request)
        {
            await _hospitalService.UpdateDepartament(request.Id, request.Name);
        }

        [HttpGet]
        public async Task<JsonResult>  GetSpecializations([FromQuery] int page, [FromQuery] int threadsPerPage = 10) //dziala
        {
            var model = await _hospitalService.GetSpecializationsAsync(page, threadsPerPage);

            var result = new SpecialityListingViewModel(model);

            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> CreateSpecialization([FromBody] CreateSpecialityRequestViewModel request)
        {
            var test = await _hospitalService.GetSpecializationByName(request.Name);
            if (test != null)
            {
                throw new InvalidCreateSpecializationException(); //gdy specjalizacja o takiej samej nazwie istnieje
            }

            var speciality = await _hospitalService.CreateSpecialization(request.Name);
            var result = new SpecialityViewModel(speciality);

            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task DeleteSpecialization([FromQuery] string id)
        {
            var model = await _hospitalService.GetSpecializationByIdAsync(id);
            await _hospitalService.DeleteSpecialization(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task UpdateSpecialization([FromBody] UpdateSpecializationRequestViewModel request)
        {
            await _hospitalService.UpdateSpecialization(request.Id, request.Name);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> CreateDoctor([FromBody] CreateDoctorRequestViewModel request) //dziala
        {
            var patient = await _hospitalService.GetPatientById(request.PatientId);

            if (patient == null) throw new InvalidGetPatientByIdException();

            var model = await _hospitalService.CreateDoctor(patient);

            var result = new DoctorViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDoctors([FromQuery] string departamentId, [FromQuery] int page,
            [FromQuery] int postsPerPage = 10)
        {
            var departament = await _hospitalService.GetDepartamentById(departamentId);

            if (departament == null) throw new InvalidDepartmanetIdException();

            var model = _hospitalService.GetDoctorsFromDepartament(departament, page, postsPerPage);

            var result = new DepartamentDoctorsListViewModel(model);

            return Json(result);
        }

        
        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDoctorsFromSpecialization([FromQuery] string specializationId, [FromQuery] int page,[FromQuery] int postsPerPage = 10) //działa
        {
            var specialization = await _hospitalService.GetSpecializationByIdAsync(specializationId);

            if (specialization == null) throw new InvalidDepartmanetIdException();

            var model = _hospitalService.GetDoctorsFromSpecialization(specialization, page, postsPerPage);


            var result = new DoctorsFromSepcializationViewModelList(model);
           

            return Json(result);
        }


        [Authorize]
        [HttpGet]
        public JsonResult GetPatients() //działa
        {
            var model = _hospitalService.GetPatients();

            var result = new PatientsListingViewModel(model);

            return Json(result);
        }


        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetSpecializationFromDoctor([FromQuery] string doctorId, [FromQuery] int page,
            [FromQuery] int postsPerPage = 10)
        {
            var doctor = await _hospitalService.GetDoctorById(doctorId);
            if (doctor == null) throw new InvalidGetDoctorByIdException();

            var model = _hospitalService.GetSpecDoctor(doctor, page, postsPerPage);
            var result = new SpecializationsFromDepartamentListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDepartamentsFromDoctor([FromQuery] string doctorId, [FromQuery] int page,
            [FromQuery] int postsPerPage = 10)
        {
            var doctor = await _hospitalService.GetDoctorById(doctorId);
            if (doctor == null) throw new InvalidGetDoctorByIdException();

            var model = _hospitalService.GetDepartamentDoctor(doctor, page, postsPerPage);
            var result = new DepartamentsFromDoctorLisingViewModel(model);

            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task AddDoctorSpecialization([FromBody] AddSpecializationToDoctorViewModel request) //działa
        {

            var doctor = await _hospitalService.GetDoctorById(request.DoctorId);
            if (doctor == null) throw new InvalidGetDoctorByIdException();
            var specialization = await _hospitalService.GetSpecializationByIdAsync(request.SpecializationId);

            var doctorWithSpec = await _hospitalService.AddDoctorSpecialization(doctor, specialization);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task AddDoctorDepartament([FromBody] AddDepartamentToDoctorRequestViewModel request) //działa
        {
            var doctor = await _hospitalService.GetDoctorById(request.DoctorId);
            if (doctor == null) throw new InvalidGetDoctorByIdException();
            var departmanet = await _hospitalService.GetDepartamentById(request.DepartamentId);
            var doctorWithDep = await _hospitalService.AddDoctorDepartament(doctor, departmanet);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task DeleteDoctorDepartament([FromQuery] string doctorId, [FromQuery] string departamentId)
        {
            var doctor = await _hospitalService.GetDoctorById(doctorId);
            var departament = await _hospitalService.GetDepartamentById(departamentId);
            await _hospitalService.DeleteDepartamentDoctor(doctor,departament);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task DeleteDoctorSpecialization([FromQuery] string doctorId, [FromQuery] string specializationId)
        {
            var doctor = await _hospitalService.GetDoctorById(doctorId);
            var specialization = await _hospitalService.GetSpecializationByIdAsync(specializationId);
            await _hospitalService.DeleteSpecialiazationDoctorAsync(doctor, specialization);
        }
    }
    
}
