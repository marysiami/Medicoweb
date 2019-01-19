using System;
using System.Collections.Generic;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/{nowy_projekt} i zmienic namespace na Medicoweb.Data.Models.{nowy_projekt}")]
    public class Prescription
    {
        public Guid Id { get; set; }
        public Guid VisitId { get; set; }
        public Visit Visit { get; set; }
        public virtual ICollection<PrescriptionDrug> PrescriptionDrug { get; set; }
    }
}