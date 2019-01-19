using System;
using System.Collections.Generic;

namespace Medicoweb.Data.Models.Hospital
{
    public class Specialization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SpecializationDoctor> SpecializationDoctor { get; set; }
    }
}