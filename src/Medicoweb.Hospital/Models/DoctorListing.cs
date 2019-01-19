using System.Collections.Generic;
using Medicoweb.Data.Models;

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