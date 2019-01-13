using SBD.DATA.Models;
using SBD.VISIT.Models;
using System;
using System.Threading.Tasks;

namespace SBD.VISIT.Contracts
{
    public interface IVisitService
    {
        Task<Visit> CreateVisit(VisitViewModel model);
        Task RemoveVisit(Guid visitId);
        Task<Visit> EditVisit(Guid visitId, VisitViewModel model);
        //Task<Visit> GetDoctorVisits(Guid doctorId);
       //Task<Visit> GetPatientVisits(Guid patientId);
    }
}
