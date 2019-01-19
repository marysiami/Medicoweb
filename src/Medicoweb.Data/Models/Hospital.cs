using System;
using System.Collections.Generic;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/Hospital i zmienic namespace na Medicoweb.Data.Models.Hospital")]
    public class Hospital
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Departament> Departaments { get; set; }
    }
}