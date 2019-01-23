using Medicoweb.Data.Models.Drug;
using Medicoweb.Data.Models.Visit;
using Medicoweb.Visit.Models;
using System.Threading.Tasks;

namespace Medicoweb.Visit.Contracts
{
    public interface IPrescriptionService
    {
        Task<Prescription> CreatePrescriptionAsync(Data.Models.Visit.Visit visit);
        Task<Prescription> GetPrescriptionById(string id);
        Task<PrescriptionListing> GetPatientPrescriptions(string patientId);
        Task AddDrugToPrescription(string prescriptionId, Drug drug, int drugQuantity);      
        Task<DrugListingFromPrescription> GetDrugsFromPrescription(Prescription prescription);
        PrescriptionListing GetPrescriptionsFromVisit(Data.Models.Visit.Visit visit);
    }
}
