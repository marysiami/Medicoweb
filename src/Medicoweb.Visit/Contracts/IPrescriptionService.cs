using Medicoweb.Data.Models;
using Medicoweb.Data.Models.Visit;
using Medicoweb.Visit.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medicoweb.Visit.Contracts
{
    public interface IPrescriptionService
    {
        Task<Prescription> CreatePrescriptionAsync(Data.Models.Visit.Visit visit);
        Task<Prescription> GetPrescriptionById(string id);
        Task<PrescriptionListing> GetPatientPrescriptions(string patientId, int skip = 0, int take = 10);
    }
}
