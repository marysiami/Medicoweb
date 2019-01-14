using Microsoft.EntityFrameworkCore;
using SBD.DATA.Contracts;
using SBD.DATA.Models;
using SBD.DATA.Models.Account;
using SBD.DATA.Models.Schedule;
using SBD.HOSPITAL.Contracts;
using SBD.USER.Contracts;
using SBD.VISIT.Contracts;
using SBD.VISIT.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.VISIT.Services
{
    public class VisitService : IVisitService
    {
        private readonly IDataService _dataService;
        private readonly IUserService _userService;
        private readonly IHospitalService _hospitalService;

        public VisitService(IDataService dataService, IUserService userService, IHospitalService hospitalService)
        {
            _dataService = dataService;
            _userService = userService;
            _hospitalService = hospitalService;            
        }

       
        public async Task<Visit> CreateVisit(SBDUser patient, Doctor doctor, VisitTime visitTime)
        {
            var model = new Visit
            {
                Patient = patient,
                Doctor = doctor,
                Date = visitTime,
                IsCancelled = false
            };

            await _dataService.GetSet<Visit>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public async Task<VisitTime> CreateVisitTime(TimeSpan start)
        {
            var newVisitTime = new VisitTime
            {
                StartTime = start,
                EndTime = start.Add(TimeSpan.FromMinutes(30)), //jedna wizyta trwa 30 minut           
                
            };
            /* Przykład TimeSpan
            TimeSpan duration = new TimeSpan(1, 12, 23, 62);
            string output = null;
            output = "Time of Travel: " + duration.ToString("%d") + " days";
            Console.WriteLine(output);
            output = "Time of Travel: " + duration.ToString(@"dd\.hh\:mm\:ss");
            */
            await _dataService.GetSet<VisitTime>().AddAsync(newVisitTime);
            await _dataService.SaveDbAsync();

            return newVisitTime;
        }

        public async Task<VisitListing> GetDoctorVisits (string doctorId, int skip = 0, int take = 10)
        {
            var doctor = await _hospitalService.GetDoctorById(doctorId);
            var model = new VisitListing
            {
                TotalCount = doctor.Visits.Count,
                Visits = doctor.Visits.ToList()
            };
            return model;
        }

        public async Task <VisitListing> GetPtientVisits(string patientId, int skip = 0, int take = 10)
        {
            var patient = await _hospitalService.GetPatientById(patientId);
            var model = new VisitListing
            {
                TotalCount = patient.Visits.Count,
                Visits =  patient.Visits
                .Skip(skip * take)
                .Take(take)
                .ToList()
        };           
            return model;
        }

        public Task <Visit> GetVisitById(string id)
        {           
            var model = _dataService.GetSet<Visit>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public void UpdateVisit(Visit visit)
        {
             _dataService.GetSet<Visit>().Update(visit);            
        }
    }
}
