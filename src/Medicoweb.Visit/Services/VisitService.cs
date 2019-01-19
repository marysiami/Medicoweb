using System;
using System.Linq;
using System.Threading.Tasks;
using Medicoweb.Account.Contracts;
using Medicoweb.Common.Attributes;
using Medicoweb.Data.Contracts;
using Medicoweb.Data.Models;
using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Schedule;
using Medicoweb.Hospital.Contracts;
using Medicoweb.Visit.Contracts;
using Medicoweb.Visit.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicoweb.Visit.Services
{
    [BadDesign("Odwołanie do innego projektu z tej samej warstwy", "Przeprojektowac tak, zeby ten serwis nie korzystal z IHospitalService")]
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

        public async Task<PrescriptionDrug> AddDrugToPrescriptionAsync(Prescription prescription, Drug drug,
            int drugQuantity)
        {
            var model = new PrescriptionDrug
            {
                DrugId = drug.Id,
                Drug = drug,
                PrescriptionId = prescription.Id,
                Prescription = prescription,
                DrugQuantity = drugQuantity
            };

            await _dataService.GetSet<PrescriptionDrug>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public async Task<Drug> CreateDrugAsync(string name, string company)
        {
            var model = new Drug
            {
                Name = name,
                Company = company
            };

            await _dataService.GetSet<Drug>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public async Task<Prescription> CreatePrescriptionAsync(Data.Models.Visit visit)
        {
            var model = new Prescription
            {
                Visit = visit,
                VisitId = visit.Id
            };

            await _dataService.GetSet<Prescription>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public async Task<Data.Models.Visit> CreateVisit(MedicowebUser patient, Doctor doctor, VisitTime visitTime)
        {
            var model = new Data.Models.Visit
            {
                Patient = patient,
                Doctor = doctor,
                Date = visitTime,
                IsCancelled = false
            };

            await _dataService.GetSet<Data.Models.Visit>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public async Task<VisitTime> CreateVisitTime(TimeSpan start)
        {
            var newVisitTime = new VisitTime
            {
                StartTime = start,
                EndTime = start.Add(TimeSpan.FromMinutes(30)) //jedna wizyta trwa 30 minut           
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

        public async Task<VisitListing> GetDoctorVisits(string doctorId, int skip = 0, int take = 10)
        {
            var doctor = await _hospitalService.GetDoctorById(doctorId);

            var model = new VisitListing
            {
                TotalCount = doctor.Visits.Count,
                Visits = doctor.Visits.ToList()
            };

            return model;
        }

        public DrugListing GetDrugs(int skip = 0, int take = 10)
        {
            var model = new DrugListing
            {
                TotalCount = _dataService.GetSet<Drug>().Count(),
                Drugs = _dataService.GetSet<Drug>().Skip(skip * take)
                    .Take(take)
                    .ToList()
            };

            return model;
        }

        public async Task<PrescriptionListing> GetPatientPrescriptions(string patientId, int skip = 0, int take = 10)
        {
            var patient = await _hospitalService.GetPatientById(patientId);
            var model = new PrescriptionListing
            {
                TotalCount = patient.Prescriptions.Count,
                Prescriptions = patient.Prescriptions
                    .Skip(skip * take)
                    .Take(take)
                    .ToList()
            };

            return model;
        }

        public Task<Prescription> GetPrescriptionById(string id)
        {
            var model = _dataService.GetSet<Prescription>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public async Task<VisitListing> GetPatientVisits(string patientId, int skip = 0, int take = 10)
        {
            var patient = await _hospitalService.GetPatientById(patientId);
            var model = new VisitListing
            {
                TotalCount = patient.Visits.Count,
                Visits = patient.Visits
                    .Skip(skip * take)
                    .Take(take)
                    .ToList()
            };

            return model;
        }


        public Task<Data.Models.Visit> GetVisitById(string id)
        {
            var model = _dataService.GetSet<Data.Models.Visit>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public async Task UpdateDrug(string id, string name, string company)
        {
            var model = await GetDrugById(id);
            model.Name = name;
            model.Company = company;

            _dataService.GetSet<Drug>().Update(model);

            await _dataService.SaveDbAsync();
        }

        public async Task DeleteDrug(string id)
        {
            var model = await GetDrugById(id);

            _dataService.GetSet<Drug>().Remove(model);

            await _dataService.SaveDbAsync();
        }

        public async Task<Drug> GetDrugById(string id)
        {
            var model = await _dataService.GetSet<Drug>().FirstOrDefaultAsync(x => x.Id.ToString() == id);

            return model;
        }
    }
}