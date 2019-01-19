using System.Collections.Generic;
using Medicoweb.Data.Models;

namespace Medicoweb.Hospital.Models
{
    public class DoctorSpecListing
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<SpecializationDoctor> Specializations { get; set; }

    }
}
