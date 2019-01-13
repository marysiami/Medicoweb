using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBD.PRESCRIPTION.Contracts
{
    public interface IPrescriptionService
    {
        Task<Prescription> AddPrescription(Guid visitId);
        Task DeletePrescription(string id);
        Task AddDrugToPrescription(Guid id, Guid Drugid, int quantity);
        Task<List<Prescription>> GetPrescriptionFromPatient(string id);
        Task<List<Prescription>> GetPrescriptionFromDoctor(string id);
        Task<List<Prescription>> GetPrescriptionFromPharm(string id);

    }

}
