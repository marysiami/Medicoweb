using Microsoft.EntityFrameworkCore;
using SBD.DATA.Contracts;
using SBD.DATA.Models;
using SBD.PRESCRIPTION.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.PRESCRIPTION.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IDataService _dataService;
        public PrescriptionService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task AddDrugToPrescription(Guid id, Guid drugId, int quantity)
        {
            var prescriptionDrug = new PrescriptionDrug
            {
                PrescriptionId = id,
                DrugId = drugId,
                DrugQuantity = quantity
            };
            var set = _dataService.GetSet<PrescriptionDrug>().AddAsync(prescriptionDrug);
            await _dataService.SaveDbAsync();
        }

        public async Task<Prescription> AddPrescription(Guid visitId)
        {

            var newPrescription = new Prescription
            {
                VisitId = visitId          
            };
            await _dataService.GetSet<Prescription>().AddAsync(newPrescription);
            await _dataService.SaveDbAsync();

            return newPrescription;
        }

        public async Task DeletePrescription(string id)
        {
            var set = _dataService.GetSet<Prescription>();
            var presc = await set.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            set.Remove(presc);
            await _dataService.SaveDbAsync();
        }

        public async Task<List<Prescription>> GetPrescriptionFromDoctor(string id)
        {
            var set = _dataService.GetSet<Visit>();
            var doctor = await set.Include(x => x.Doctor).ThenInclude(y => y.Id)
                .FirstOrDefaultAsync(x => x.Id.ToString() == id);
            List<Prescription> prescriptions = doctor.Prescription.ToList(); // nie bardzo to
             
            return prescriptions;
        }

        public async Task<List<Prescription>> GetPrescriptionFromPatient(string id)
        {
            var set = _dataService.GetSet<Visit>();
            var patient = await set.Include(x => x.Patient).ThenInclude(y => y.Id)
                .FirstOrDefaultAsync(x => x.Id.ToString() == id);
            var prescriptions = patient.Prescription.ToList();

            return prescriptions;
        }

        public Task<List<Prescription>> GetPrescriptionFromPharm(string id) //super mega zawiłe -> jak zrobie zakupy w aptece
        {
            throw new NotImplementedException();
        }
    }
}
