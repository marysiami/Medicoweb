using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.DATA.Models
{
    public class Departament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection <DepartamentDoctor> DepartamentDoctors { get; set; }
    }
}
