using System;
using System.Collections.Generic;

namespace Medicoweb.Data.Models
{
    public class Pharmacy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<PharmacyDrug> PharmacyDrugs { get; set; }
    }
}