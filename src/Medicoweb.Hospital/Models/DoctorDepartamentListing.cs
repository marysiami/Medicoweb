using Medicoweb.Data.Models.Hospital;
using System.Collections.Generic;

namespace Medicoweb.Hospital.Models
{
    public class DoctorDepartamentListing
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<DepartamentDoctor> Departaments { get; set; }
    }
}