using SBD.DATA.Models;
using System.Collections.Generic;

namespace SBD.HOSPITAL.Models
{
    public class DoctorListing
    {
        public List<Doctor> Doctors { get; set; }
        public int TotalCount { get; set; }
        public string HospitalName { get; set; }
        public string DepartamentName { get; set; }
    }
}
