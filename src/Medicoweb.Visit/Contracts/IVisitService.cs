using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Hospital;
using Medicoweb.Visit.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medicoweb.Visit.Contracts
{
    public interface IVisitService
    {
        Task<Data.Models.Visit.Visit> CreateVisit(MedicowebUser patient, Doctor doctor, DateTime visitTime, Data.Models.Hospital.Hospital hospital);
        Task<VisitListing> GetPatientVisits(string patientId);
        Task<VisitListing> GetDoctorVisits(string doctorId);        
        Task<Data.Models.Visit.Visit> GetVisitById(string id); 
        List<DateTime> GetHoursFromDay(DateTime date);
    }
}