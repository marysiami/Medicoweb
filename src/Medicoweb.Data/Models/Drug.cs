using System;
using System.Collections.Generic;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/{nowy_projekt dla lekow lub aptek} i zmienic namespace na Medicoweb.Data.Models.{nowy_projekt dla lekow lub aptek}")]
    public class Drug
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public virtual ICollection<PharmacyDrug> PharmacyDrugs { get; set; }
        public virtual ICollection<PrescriptionDrug> PrescriptionDrug { get; set; }
    }
}