using System.Collections.Generic;
using Medicoweb.Data.Models;

namespace Medicoweb.Hospital.Models
{
    public class DepartamentListing
    {
        public List<Departament> Departaments { get; set; }
        public int TotalCount { get; set; }
        public string HospitalName { get; set; }
    }
}
