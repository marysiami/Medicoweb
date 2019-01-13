using SBD.DATA.Models;
using System.Collections.Generic;

namespace SBD.HOSPITAL.Models
{
    public class DoctorSpecListing
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<SpecializationDoctor> Specializations { get; set; }

    }
}
