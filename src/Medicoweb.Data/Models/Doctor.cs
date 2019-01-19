using System;
using System.Collections.Generic;
using Medicoweb.Data.Models.Schedule;

namespace Medicoweb.Data.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public virtual DoctorTime TimeOfWork { get; set; }
        public virtual ICollection<DepartamentDoctor> DepartamentDoctors { get; set; }
        public virtual ICollection<SpecializationDoctor> SpecializationDoctor { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}