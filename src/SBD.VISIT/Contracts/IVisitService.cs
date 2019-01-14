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

    }
}
