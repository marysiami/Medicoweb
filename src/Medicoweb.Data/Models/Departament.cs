using Medicoweb.Common.Attributes;
using System;
using System.Collections.Generic;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/Hospital i zmienic namespace na Medicoweb.Data.Models.Hospital")]
    public class Departament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<DepartamentDoctor> DepartamentDoctors { get; set; }
    }
}