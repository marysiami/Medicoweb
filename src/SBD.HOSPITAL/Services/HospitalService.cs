﻿using Microsoft.EntityFrameworkCore;
using SBD.DATA.Contracts;
using SBD.DATA.Models;
using SBD.HOSPITAL.Contracts;
using SBD.HOSPITAL.Models;
using SBD.USER.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.HOSPITAL.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IDataService _dataService;
        private readonly IUserService _userService;

        public HospitalService(IDataService dataService, IUserService userService)
        {
            _dataService = dataService;
            _userService = userService;
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

        public async Task<Departament> CreateDepartamentAsync(string name, Hospital hospital) //działa
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

        public async Task<Doctor> CreateDoctor(Patient patient)
        {
            var newDoctor = new Doctor
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Pesel = patient.Pesel,

            };
            await _dataService.GetSet<Doctor>().AddAsync(newDoctor);
            await _dataService.SaveDbAsync();

            return newDoctor;
        }

        public async Task<Hospital> CreateHospital(string name, string address) //działa
        {
            var newHospital = new Hospital
            {
                Name = name,
                Address = address
            };
            await _dataService.GetSet<Hospital>().AddAsync(newHospital);
            await _dataService.SaveDbAsync();

            return newHospital;
        }

        public async Task<Specialization> CreateSpecialization(string name)
        {
            var newSpecialization = new Specialization
            {
                Name = name,
            };
            await _dataService.GetSet<Specialization>().AddAsync(newSpecialization);
            await _dataService.SaveDbAsync();

            return newSpecialization;
        }

        public async Task<Departament> GetDepartamentById(string id)
        {
            var model = await _dataService.GetSet<Departament>()
                .Include(x=>x.Hospital)
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
                .Select(x=> x.Doctor)
               .Skip(skip * take)
               .Take(take)
               .ToList()
            }; 
            return result;

        }
        
        public async Task<Hospital> GetHospital(string hospitalId)//dziala
        {
            var hospital = await _dataService.GetSet<Hospital>()
               .Include(x => x.Departaments)               
               .FirstOrDefaultAsync(x => x.Id.ToString() == hospitalId);

            return hospital;
        }

        public async Task<HospitalListing> GetHospitalByName(int skip = 0, int take = 10)
        {
            var result = new HospitalListing();

            var query = _dataService.GetSet<Hospital>()
                .OrderByDescending(x => x.Name);

            result.TotalCount = query.Count();
            result.Hospitals = await query
                .Include(x => x.Departaments)
                .Skip(skip * take)
                .Take(take)
                .ToListAsync();

            return result;
        }

        public DepartamentListing GetHospitalDepartamenst(Hospital hospital, int skip = 0, int take = 10) //dziala
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

        public async Task<Patient> GetPatientById(string id)
        {
            var model = await _dataService.GetSet<Patient>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public PatientListing GetPatients()
        {
            var model = _dataService.GetSet<Patient>().ToList();
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
                .Where(x => x.DoctorId == doctor.Id)
                .Skip(skip * take)
                .Take(take)
                .ToList()
            };
            //wiecej filtrow?
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

    }
}