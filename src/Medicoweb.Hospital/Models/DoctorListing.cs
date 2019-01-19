using Medicoweb.Data.Models.Hospital;
using System.Collections.Generic;

namespace Medicoweb.Hospital.Models
{
    public class DoctorListing
    {
        public List<Doctor> Doctors { get; set; }
        public int TotalCount { get; set; }
        public string HospitalName { get; set; }
        public string DepartamentName { get; set; }
    }
}