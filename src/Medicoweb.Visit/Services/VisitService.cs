using Medicoweb.Account.Contracts;
using Medicoweb.Data.Contracts;
using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Hospital;
using Medicoweb.Hospital.Contracts;
using Medicoweb.Visit.Contracts;
using Medicoweb.Visit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicoweb.Visit.Services
{
    public class VisitService : IVisitService
    {
        private readonly IDataService _dataService;
        private readonly IHospitalService _hospitalService;
        private readonly IUserService _userService;

        public VisitService(IDataService dataService, IUserService userService, IHospitalService hospitalService)
        {
            _dataService = dataService;
            _userService = userService;
            _hospitalService = hospitalService;
        }
        
       
        public async Task<Data.Models.Visit.Visit> CreateVisit(MedicowebUser patient, Doctor doctor, DateTime visitTime, Data.Models.Hospital.Hospital hospital)
        {
            var model = new Data.Models.Visit.Visit
            {
                Hospital = hospital,
                Patient = patient,
                Doctor = doctor,
                Start = visitTime,
                End = visitTime.AddMinutes(30)

            };

            await _dataService.GetSet<Data.Models.Visit.Visit>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        

        public async Task<VisitListing> GetDoctorVisits(string doctorId)
        {
            var doctor = await _hospitalService.GetDoctorById(doctorId);
            var model = new VisitListing
            {
                Visits = _dataService.GetSet<Data.Models.Visit.Visit>()
                .Where(x => x.DoctorId.ToString() == doctorId)
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Include(x => x.Hospital)
                .ToList()
            };
            return model;
        }
             

        public List<DateTime> GetHoursFromDay(DateTime date)
        {
            var visitTimes = new List<DateTime> { };
            DateTime start = date.AddHours(8);
            DateTime end = date.AddHours(15);
            DateTime visit = start;
            visitTimes.Add(visit);

            for (var i=0; i < 15; i++)
            {
                visit = visit.AddMinutes(30);
                visitTimes.Add(visit);
            }

            var reservedDate = _dataService.GetSet<Data.Models.Visit.Visit>().Where(x=>x.Start == date).ToList();
            if(reservedDate != null)
            {
                for(int i=0; i < reservedDate.Count(); i++)
                {
                    var reservedTime = reservedDate[i].Start;
                    visitTimes.Remove(reservedTime);
                }
                
            }
            
            
            return visitTimes;      
        }

       

        public async Task<PrescriptionListing> GetPatientPrescriptions(string patientId)
        {
            var patient = await _hospitalService.GetPatientById(patientId);
            var model = new PrescriptionListing
            {
                Prescriptions = _dataService.GetSet<Data.Models.Visit.Prescription>()
                .Where(x => x.Visit.PatientId.ToString() == patientId).Include(x=>x.PrescriptionDrug)//ThenInclude(x=>x.Drug)
                .ToList()
            };
            return model;
        }


        public async Task<VisitListing> GetPatientVisits(string patientId)
        {
            var patient = await _hospitalService.GetPatientById(patientId);
            var model = new VisitListing
            {
                Visits =  _dataService.GetSet<Data.Models.Visit.Visit>()
                .Where(x => x.PatientId.ToString() == patientId)
                .Include(x=>x.Doctor)
                .Include(x=>x.Patient)
                .Include(x=>x.Hospital)
                .ToList()
            };
            return model;
        }


        public Task<Data.Models.Visit.Visit> GetVisitById(string id)
        {
            var model = _dataService.GetSet<Data.Models.Visit.Visit>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

    }
}