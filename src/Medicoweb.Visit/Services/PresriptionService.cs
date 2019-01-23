using Medicoweb.Data.Contracts;
using Medicoweb.Data.Models.Drug;
using Medicoweb.Data.Models.Visit;
using Medicoweb.Hospital.Contracts;
using Medicoweb.Visit.Contracts;
using Medicoweb.Visit.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Medicoweb.Visit.Services
{
    public class PresriptionService : IPrescriptionService
    {
        private readonly IDataService _dataService;
        private readonly IHospitalService _hospitalService;
  

        public PresriptionService(IDataService dataService,IHospitalService hospitalService)
        {
            _dataService = dataService;
            _hospitalService = hospitalService;
        }

        public async Task<Prescription> CreatePrescriptionAsync(Data.Models.Visit.Visit visit)
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

        public async Task AddDrugToPrescription(string prescriptionId, Drug drug, int drugQuantity)
        {            
            var prescription = await GetPrescriptionById(prescriptionId);
            var model = new PrescriptionDrug
            {
                DrugId = drug.Id,
                PrescriptionId = prescription.Id,
                DrugQuantity = drugQuantity
            };
            await _dataService.GetSet<PrescriptionDrug>().AddAsync(model);
            await _dataService.SaveDbAsync();
        }

    
        public Task<Prescription> GetPrescriptionById(string id)
        {
            var model = _dataService.GetSet<Prescription>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;

        }
        public  async Task<DrugListingFromPrescription> GetDrugsFromPrescription(Prescription prescription)
        {
            var model = new DrugListingFromPrescription
            {
                TotalCount = prescription.PrescriptionDrug.Count,
                Drugs =  await _dataService.GetSet<PrescriptionDrug>()
                .Where(x => x.PrescriptionId == prescription.Id)
                .Include(x => x.Drug)
                .Include(x=>x.DrugQuantity)                                         
                .ToListAsync()
            };
            return model;
        }
        public async Task<PrescriptionListing> GetPatientPrescriptions(string patientId)
        {
            var patient = await _hospitalService.GetPatientById(patientId);
            var model = new PrescriptionListing
            {
                Prescriptions = _dataService.GetSet<Prescription>()                
                .Where(x => x.Visit.PatientId.ToString() == patientId)
                .Include(x => x.PrescriptionDrug)
                .ToList()
            };
            return model;
        }

        public PrescriptionListing GetPrescriptionsFromVisit(Data.Models.Visit.Visit visit)
        {            
            var model = new PrescriptionListing
            {
                Prescriptions = _dataService.GetSet<Prescription>()
                .Where(x => x.Visit == visit)
                .Include(x => x.PrescriptionDrug)
                .ToList()
            };
            return model;
        }
    }
}
