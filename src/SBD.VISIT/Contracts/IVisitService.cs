using SBD.DATA.Models;
using SBD.DATA.Models.Account;
using SBD.DATA.Models.Schedule;
using SBD.VISIT.Models;
using System;
using System.Threading.Tasks;

namespace SBD.VISIT.Contracts
{
    public interface IVisitService
    {
        Task<Visit> CreateVisit(SBDUser patient, Doctor doctor, VisitTime visitTime);
        Task<VisitListing> GetPtientVisits(string patientId, int skip = 0, int take = 10);
        Task<VisitListing> GetDoctorVisits(string doctorId, int skip = 0, int take = 10);


        void UpdateVisit(Visit visit);
        Task <Visit> GetVisitById(string id);
        Task<VisitTime> CreateVisitTime(TimeSpan start);

        Task<Prescription> CreatePrescriptionAsync(Visit visit);
        Task<Drug> CreateDrugAsync(string name, string company);
        Task<Drug> GetVDrugById(string id);
        DrugListing GetDrugs(int skip = 0, int take = 10);
        Task<Prescription> GetPrescriptionById(string id);
        Task<PrescriptionListing> GetPatientPrescriptions(string patientId, int skip = 0, int take = 10);
        Task<PrescriptionDrug> AddDrugToPrescriptionAsync(Prescription  prescription, Drug drug, int drugQuantity);
      //  Task RemoveDrugFromPrescription(string visitId, string drugId);



    }
}
