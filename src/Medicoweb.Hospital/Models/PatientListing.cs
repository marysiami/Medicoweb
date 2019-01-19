using System.Collections.Generic;
using Medicoweb.Data.Models.Account;

namespace Medicoweb.Hospital.Models
{
    public class PatientListing
    {
        public List<MedicowebUser> Patients { get; set; }
        public int TotalCount { get; set; }
    }
}