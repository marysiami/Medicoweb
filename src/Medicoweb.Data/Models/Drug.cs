using System;
using System.Collections.Generic;

namespace Medicoweb.Data.Models
{
    public class Drug
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public virtual ICollection<PharmacyDrug> PharmacyDrugs { get; set; }
        public virtual ICollection<PrescriptionDrug> PrescriptionDrug { get; set; }
    }
}