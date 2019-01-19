using System;
using System.Collections.Generic;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/{nowy_projekt dla lekow lub aptek} i zmienic namespace na Medicoweb.Data.Models.{nowy_projekt dla lekow lub aptek}")]
    public class Pharmacy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<PharmacyDrug> PharmacyDrugs { get; set; }
    }
}