using SBD.DATA.Models;
using System.Collections.Generic;

namespace SBD.HOSPITAL.Models
{
    public class PatientListing
    {
        public List<Patient> Patients { get; set; }
        public int TotalCount { get; set; }
    }
}
