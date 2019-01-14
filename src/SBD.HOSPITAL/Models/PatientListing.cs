using SBD.DATA.Models.Account;
using System.Collections.Generic;

namespace SBD.HOSPITAL.Models
{
    public class PatientListing
    {
        public List<SBDUser> Patients { get; set; }
        public int TotalCount { get; set; }
    }
}
