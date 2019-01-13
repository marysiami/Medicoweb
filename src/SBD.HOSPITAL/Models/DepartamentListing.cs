using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.HOSPITAL.Models
{
    public class DepartamentListing
    {
        public List<Departament> Departaments { get; set; }
        public int TotalCount { get; set; }
        public string HospitalName { get; set; }
    }
}
