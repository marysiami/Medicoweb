using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.HOSPITAL.Models
{
    public class DoctorDepartamentListing
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<DepartamentDoctor> Departaments { get; set; }

    }
}
