using System.Linq;
using System.Threading.Tasks;
using Medicoweb.Account.Contracts;
using Medicoweb.Data.Contracts;
using Medicoweb.Data.Models;
using Medicoweb.Data.Models.Account;
using Medicoweb.Hospital.Contracts;
using Medicoweb.Hospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Medicoweb.Hospital.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IDataService _dataService;
        private readonly IUserService _userService;
        private readonly UserManager<SBDUser> _userManager;

        public HospitalService(IDataService dataService, IUserService userService, UserManager<SBDUser> userManager)
        {
            _dataService = dataService;
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<Doctor> AddDoctorDepartament(Doctor doctor, Departament departament)
        {
            var DoctorDepartament = new DepartamentDoctor
            {
                Doctor = doctor,
                Departament = departament,
                DoctorId = doctor.Id,
                DepartamentId = departament.Id,
            };
            await _dataService.GetSet<DepartamentDoctor>().AddAsync(DoctorDepartament);

            return doctor; // zwrocic viewmodel?
        }

        public async Task<Doctor> AddDoctorSpecialization(Doctor doctor, Specialization specialization)
        {
            var SpecDoc = new SpecializationDoctor
            {
                Doctor = doctor,
                Specialization = specialization,
                DoctorId = doctor.Id,
                SpecializationId = specialization.Id,
            };
            await _dataService.GetSet<SpecializationDoctor>().AddAsync(SpecDoc);

            return doctor;// zwrocic viewmodel?
        }

        public async Task<Departament> CreateDepartamentAsync(string name, Data.Models.Hospital hospital) //działa
        {
            var newDepartament = new Departament
            {
                Name = name,
                Hospital = hospital
            };
            await _dataService.GetSet<Departament>().AddAsync(newDepartament);
            await _dataService.SaveDbAsync();

            return newDepartament;
        }

        public async Task<Doctor> CreateDoctor(SBDUser patient)
        {
            var newDoctor = new Doctor
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Pesel = patient.Pesel,

            };
            await _userManager.RemoveFromRoleAsync(patient, "Patient");
            await _userManager.AddToRoleAsync(patient, "Doctor");


            await _dataService.GetSet<Doctor>().AddAsync(newDoctor);
            await _dataService.SaveDbAsync();

            return newDoctor;
        }

        public async Task<Data.Models.Hospital> CreateHospital(string name, string address) //działa
        {
            var newHospital = new Data.Models.Hospital
            {
                Name = name,
                Address = address
            };
            await _dataService.GetSet<Data.Models.Hospital>().AddAsync(newHospital);
            await _dataService.SaveDbAsync();

            return newHospital;
        }

        public async Task<Specialization> CreateSpecialization(string name) //działa
        {
            var newSpecialization = new Specialization
            {
                Name = name,
            };
            await _dataService.GetSet<Specialization>().AddAsync(newSpecialization);
            await _dataService.SaveDbAsync();

            return newSpecialization;
        }

        public void DeleteDepartament(Departament departament)
        {
            _dataService.GetSet<Departament>().Remove(departament);
        }

        public void DeleteSpecialization(Specialization specialization)
        {
            _dataService.GetSet<Specialization>().Remove(specialization);
        }

        public async Task<Departament> GetDepartamentById(string id)
        {
            var model = await _dataService.GetSet<Departament>()
                .Include(x => x.Hospital)
                .Include(x => x.DepartamentDoctors)
                .ThenInclude(x => x.Doctor)
                .FirstOrDefaultAsync(x => x.Id.ToString() == id);
            var i = model.Hospital;
            return model;
        }

        public DoctorDepartamentListing GetDepartamentDoctor(Doctor doctor, int skip = 0, int take = 10)
        {
            var result = new DoctorDepartamentListing
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Departaments = doctor.DepartamentDoctors
                .Skip(skip * take)
                .Take(take)
                .ToList()
            };

            return result;
        }

        public async Task<Doctor> GetDoctorById(string id)
        {
            var model = await _dataService.GetSet<Doctor>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public DoctorListing GetDoctorsFromDepartament(Departament departament, int skip = 0, int take = 10)
        {
            var result = new DoctorListing
            {
                HospitalName = departament.Hospital.Name,
                DepartamentName = departament.Name,
                TotalCount = departament.DepartamentDoctors.Count(),

                Doctors = departament.DepartamentDoctors
                .Select(x => x.Doctor)
               .Skip(skip * take)
               .Take(take)
               .ToList()
            };
            return result;

        }

        public async Task<Data.Models.Hospital> GetHospital(string hospitalId)//dziala
        {
            var hospital = await _dataService.GetSet<Data.Models.Hospital>()
               .Include(x => x.Departaments)
               .FirstOrDefaultAsync(x => x.Id.ToString() == hospitalId);

            return hospital;
        }

        public async Task<HospitalListing> GetHospitalsByName(int skip = 0, int take = 10)
        {
            var result = new HospitalListing();

            var query = _dataService.GetSet<Data.Models.Hospital>()
                .OrderByDescending(x => x.Name);

            result.TotalCount = query.Count();
            result.Hospitals = await query
                .Include(x => x.Departaments)
                .Skip(skip * take)
                .Take(take)
                .ToListAsync();

            return result;
        }

        public DepartamentListing GetHospitalDepartamenst(Data.Models.Hospital hospital, int skip = 0, int take = 10) //dziala
        {
            var result = new DepartamentListing
            {
                HospitalName = hospital.Name,
                TotalCount = hospital.Departaments.Count(),
                Departaments = hospital.Departaments
                .OrderBy(x => x.Name)
                .Skip(skip * take)
                .Take(take)
                .ToList()
            };

            return result;
        }

        public async Task<SBDUser> GetPatientById(string id)
        {
            var model = await _dataService.GetSet<SBDUser>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public PatientListing GetPatients() //działa
        {
            var obj = _dataService.GetSet<SBDUser>().ToList();
            var model = obj.Where(x => _userManager.IsInRoleAsync(x, "Patient").Result).ToList();

            var list = new PatientListing
            {
                Patients = model,
                TotalCount = model.Count()
            };

            return list;


        }

        public DoctorSpecListing GetSpecDoctor(Doctor doctor, int skip = 0, int take = 10)
        {
            var result = new DoctorSpecListing
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Specializations = doctor.SpecializationDoctor
                .Skip(skip * take)
                .Take(take)
                .ToList()
            };

            return result;
        }

        public async Task<Specialization> GetSpecializationByIdAsync(string id)
        {
            var model = await _dataService.GetSet<Specialization>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public async Task<SpecializationListing> GetSpecializationsAsync(int skip = 0, int take = 10)
        {
            var result = new SpecializationListing();

            var query = _dataService.GetSet<Specialization>()
                .OrderByDescending(x => x.Name);

            result.TotalCount = query.Count();
            result.Specialization = await query
                .OrderByDescending(x => x.Name)
                .Skip(skip * take)
                .Take(take)
                .ToListAsync();

            return result;
        }

        public async Task UpdateSpecialization(string id, string name)
        {
            var model = await GetSpecializationByIdAsync(id);
            model.Name = name;

            _dataService.GetSet<Specialization>().Update(model);
        }

        public async Task<Data.Models.Hospital> GetHospitalByName(string name)
        {
            var model = await _dataService.GetSet<Data.Models.Hospital>().FirstOrDefaultAsync(x => x.Name == name);
            return model;
        }

        public async Task<Departament> GetDepartamentByName(string name)
        {
            var model = await _dataService.GetSet<Departament>().FirstOrDefaultAsync(x => x.Name == name);
            return model;
        }

        public async Task<Specialization> GetSpecializationByName(string name)
        {
            var model = await _dataService.GetSet<Specialization>().FirstOrDefaultAsync(x => x.Name == name);
            return model;
        }

        public async Task<HospitalListing> GetoHospitalsByAddressAsync(int skip = 0, int take = 10)
        {
            var result = new HospitalListing();

            var query = _dataService.GetSet<Data.Models.Hospital>()
                .OrderByDescending(x => x.Address);

            result.TotalCount = query.Count();
            result.Hospitals = await query
                .Include(x => x.Departaments)
                .Skip(skip * take)
                .Take(take)
                .ToListAsync();

            return result;
        }

        public async Task<SpecializationListing> GetSpecializationsByName(int skip = 0, int take = 10)
        {
            var result = new SpecializationListing();

            var query = _dataService.GetSet<Specialization>()
                .OrderByDescending(x => x.Name);

            result.TotalCount = query.Count();
            result.Specialization = await query
                .Skip(skip * take)
                .Take(take)
                .ToListAsync();

            return result;
        }

        public PatientListing GetPatientsByName()
        {
            var obj = _dataService.GetSet<SBDUser>().OrderByDescending(x => x.Name).ToList();
            var model = obj.Where(x => _userManager.IsInRoleAsync(x, "Patient").Result).ToList();

            var list = new PatientListing
            {
                Patients = model,
                TotalCount = model.Count()
            };

            return list;
        }

        public PatientListing GetPatientBySurname()
        {
            var obj = _dataService.GetSet<SBDUser>().OrderByDescending(x => x.Surname).ToList();
            var model = obj.Where(x => _userManager.IsInRoleAsync(x, "Patient").Result).ToList();

            var list = new PatientListing
            {
                Patients = model,
                TotalCount = model.Count()
            };

            return list;
        }

        public PatientListing GetPatientByPesel()
        {
            var obj = _dataService.GetSet<SBDUser>().OrderByDescending(x => x.Pesel).ToList();
            var model = obj.Where(x => _userManager.IsInRoleAsync(x, "Patient").Result).ToList();

            var list = new PatientListing
            {
                Patients = model,
                TotalCount = model.Count()
            };

            return list;
        }

        public async Task UpdateDepartament(string id, string name)
        {
            var model = await GetDepartamentById(id);
            model.Name = name;
            _dataService.GetSet<Departament>().Update(model);
        }

        public async Task UpdateHospital(string id, string name, string address)
        {
            var model = await GetHospital(id);
            model.Name = name;
            model.Address = address;
            _dataService.GetSet<Data.Models.Hospital>().Update(model);
        }

    }
}