using System;
using System.Collections.Generic;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/Hospital i zmienic namespace na Medicoweb.Data.Models.Hospital")]
    public class Specialization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SpecializationDoctor> SpecializationDoctor { get; set; }
    }
}