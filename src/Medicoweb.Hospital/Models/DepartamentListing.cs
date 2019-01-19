using Medicoweb.Data.Models.Hospital;
using System.Collections.Generic;

namespace Medicoweb.Hospital.Models
{
    public class DepartamentListing
    {
        public List<Departament> Departaments { get; set; }
        public int TotalCount { get; set; }
        public string HospitalName { get; set; }
    }
}