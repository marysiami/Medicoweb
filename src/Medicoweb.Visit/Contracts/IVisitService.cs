using System;
using System.Threading.Tasks;
using Medicoweb.Common.Attributes;
using Medicoweb.Data.Models;
using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Schedule;
using Medicoweb.Visit.Models;

namespace Medicoweb.Visit.Contracts
{
    [BadDesign("Serwis udostępnia funkcjonalności nie tylko do wizyt", "Dodać nowy projekt dla Apteki/Lekow i w nim Utworzyc oddzielne serwisy dla lekow i dla recept")]
    public interface IVisitService
    {
        Task<Data.Models.Visit> CreateVisit(MedicowebUser patient, Doctor doctor, VisitTime visitTime);
        Task<VisitListing> GetPatientVisits(string patientId, int skip = 0, int take = 10);
        Task<VisitListing> GetDoctorVisits(string doctorId, int skip = 0, int take = 10);


        Task UpdateDrug(string id, string name, string company);
        Task<Data.Models.Visit> GetVisitById(string id);
        Task<VisitTime> CreateVisitTime(TimeSpan start);

        Task<Prescription> CreatePrescriptionAsync(Data.Models.Visit visit);
        Task<Drug> CreateDrugAsync(string name, string company);
        Task<Drug> GetDrugById(string id);
        DrugListing GetDrugs(int skip = 0, int take = 10);
        Task DeleteDrug(string id);

        Task<Prescription> GetPrescriptionById(string id);
        Task<PrescriptionListing> GetPatientPrescriptions(string patientId, int skip = 0, int take = 10);

        Task<PrescriptionDrug> AddDrugToPrescriptionAsync(Prescription prescription, Drug drug, int drugQuantity);
        //  Task RemoveDrugFromPrescription(string visitId, string drugId);
    }
}