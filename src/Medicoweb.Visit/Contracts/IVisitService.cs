using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Hospital;
using Medicoweb.Data.Models.Schedule;
using Medicoweb.Visit.Models;
using System;
using System.Threading.Tasks;

namespace Medicoweb.Visit.Contracts
{
    public interface IVisitService
    {
        Task<Data.Models.Visit.Visit> CreateVisit(MedicowebUser patient, Doctor doctor, VisitTime visitTime);
        Task<VisitListing> GetPatientVisits(string patientId, int skip = 0, int take = 10);
        Task<VisitListing> GetDoctorVisits(string doctorId, int skip = 0, int take = 10);        
        Task<Data.Models.Visit.Visit> GetVisitById(string id);

        Task<VisitTime> CreateVisitTime(TimeSpan start);
       
    }
}