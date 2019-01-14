using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBD.COMMON.Exceptions;
using SBD.DATA.Models;
using SBD.HOSPITAL.Contracts;
using SBD.USER.Contracts;
using SBD.WEB.ViewModels;
using SBD.WEB.ViewModels.Request;
using System;
using System.Threading.Tasks;

namespace SBD.WEB.Controllers
{
    public class HospitalController : SBDBaseController
    {
        private readonly IUserService _userService;
        private readonly IHospitalService _hospitalService;


        public HospitalController(
              IHospitalService hospitalService,
            IUserService userService)
        {
            _hospitalService = hospitalService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<JsonResult> GetHospitals([FromQuery] int page, [FromQuery] int threadsPerPage = 10)
        {
            var model = await _hospitalService.GetHospitalsByName(page, threadsPerPage);

            var result = new HospitalListingViewModel(model);

            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetDepartamentsFromHospital([FromQuery]string hospitalId, [FromQuery] int page, [FromQuery] int postsPerPage = 10)
        {
            var hospital = await _hospitalService.GetHospital(hospitalId);

            if (hospital == null)
            {
                throw new InvalidDepartmanetIdException();
            }

            var model = _hospitalService.GetHospitalDepartamenst(hospital, page, postsPerPage);

            var result = new DepartamentListViewModel(model);

            return Json(result);
        }

        [Authorize ]
        [HttpPost]
        public async Task<JsonResult> CreateHospital([FromBody]CreateHospitalRequestViewModel request)//dziala
        {
            var test = await _hospitalService.GetHospitalByName(request.Name);
            if (test == null)
            {
                throw new InvalidCreateHospitalException();//gdy szpital o takiej samej nazwie istnieje

            }
            else
            {

                var hospital = await _hospitalService.CreateHospital(request.Name, request.Address);
                var result = new HospitalViewModel(hospital);

                return Json(result);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task UpdateHospital([FromBody] string id)
        {
            var model = await _hospitalService.GetHospital(id);
            _hospitalService.UpdateHospital(model);

        }


        [Authorize ]
        [HttpPost]
        public async Task<JsonResult> CreateDepartament([FromBody]CreateDepartamentRequestViewModel request) //dziala
        {
            var test =  await _hospitalService.GetDepartamentByName(request.Name);
            if (test == null)
            {
                throw new InvalidCreateDepartamentException();//gdy departament o takiej samej nazwie istnieje

            }
            else
            {
                var hospital = await _hospitalService.GetHospital(request.HospitalId);
                if (hospital == null)
                {
                    throw new InvalidPostThreadIdException();
                }

                var departament = await _hospitalService.CreateDepartamentAsync(request.Name, hospital);
                var result = new DepartamentViewModel(departament);

                return Json(result);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task DeleteDepartament([FromBody] string id)
        {
            var model = await _hospitalService.GetDepartamentById(id);
            _hospitalService.DeleteDepartament(model);

        }

        [Authorize]
        [HttpPut]
        public async Task UpdateDepartament([FromBody] string id)
        {
            var model = await _hospitalService.GetDepartamentById(id);
            _hospitalService.UpdateDepartament(model);

        }


        [HttpGet]
        public async Task<JsonResult> GetSpecializations([FromQuery] int page, [FromQuery] int threadsPerPage = 10)//dziala
        {
            var model = await _hospitalService.GetSpecializationsAsync(page, threadsPerPage);

            var result = new SpecialityListingViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CreateSpecialization([FromBody]CreateSpecialityRequestViewModel request)
        { 
            var test =  await _hospitalService.GetSpecializationByName(request.Name);
            if (test != null)
            {
                throw new InvalidCreateSpecializationException();//gdy specjalizacja o takiej samej nazwie istnieje
            }
            else
            {
                var speciality = await _hospitalService.CreateSpecialization(request.Name);
                var result = new SpecialityViewModel(speciality);

                return Json(result);
            }            
        }

        [Authorize]
        [HttpDelete]
        public async Task DeleteSpecialization([FromBody] string id)
        {
            var model = await _hospitalService.GetSpecializationByIdAsync(id);
            _hospitalService.DeleteSpecialization(model);

        }

        [Authorize]
        [HttpPut]
        public async Task UpdateSpecialization([FromBody] string id)
        {
            var model = await _hospitalService.GetSpecializationByIdAsync(id);
            _hospitalService.UpdateSpecialization(model);

        }

        [Authorize]
        [HttpPost] 
        public async Task<JsonResult> CreateDoctor([FromQuery]string patientId) //powinno byc ok
        {
            var patient = await _hospitalService.GetPatientById(patientId);

            if (patient == null)
            {
                throw new InvalidGetPatientByIdException();
            }

            var model = await _hospitalService.CreateDoctor(patient);

            var result = new DoctorViewModel(model);

            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDoctors([FromQuery]string departamentId, [FromQuery] int page, [FromQuery] int postsPerPage = 10)
        {
            var departament = await _hospitalService.GetDepartamentById(departamentId);

            if (departament == null)
            {
                throw new InvalidDepartmanetIdException();
            }

            var model = _hospitalService.GetDoctorsFromDepartament(departament, page, postsPerPage);

        //    var result = new DepartamentListViewModel(model);

            return Json(model);
        }

        [Authorize]
        [HttpPost]
        public async Task <JsonResult> AddDoctorDepartament ([FromQuery]string doctorId, [FromQuery]string departamentId)
        {
            var doctor = await _hospitalService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                throw new InvalidGetDoctorByIdException();
            }
            var departmanet = await _hospitalService.GetDepartamentById(departamentId);
            var doctorWithDep = await _hospitalService.AddDoctorDepartament(doctor, departmanet);

            return Json(doctorWithDep);//CO zwrócic?
        }

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetDoctorsFromDep([FromQuery]string departamentId, [FromQuery] int page, [FromQuery] int postsPerPage = 10)  //powinno działać-> jak będą lekarze przetestowac 
        {
            var departament = await _hospitalService.GetDepartamentById(departamentId);

            if (departament == null)
            {
                throw new InvalidDepartmanetIdException();
            }

            var model = _hospitalService.GetDoctorsFromDepartament(departament, page, postsPerPage);


            var result = new DoctorListingViewModel(model);
           
            return Json(result);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetPatients() //działa
        {
            var model =  _hospitalService.GetPatients();

            var result = new PatientsListingViewModel(model);

            return Json(result);
          
        }
 
      
    }
}
