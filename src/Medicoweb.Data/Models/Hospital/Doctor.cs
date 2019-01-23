using System;
using System.Collections.Generic;

namespace Medicoweb.Data.Models.Hospital
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }       
        public virtual ICollection<DepartamentDoctor> DepartamentDoctors { get; set; }
        public virtual ICollection<SpecializationDoctor> SpecializationDoctor { get; set; }
        public virtual ICollection<Visit.Visit> Visits { get; set; }
    }
}