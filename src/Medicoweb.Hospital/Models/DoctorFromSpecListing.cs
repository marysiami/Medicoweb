using Medicoweb.Data.Models.Hospital;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medicoweb.Hospital.Models
{
    public class DoctorFromSpecListing
    {
        public string SpecializationName { get; set; }
        public int TotalCount { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
