using System;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/{nowy_projekt dla lekow lub aptek} i zmienic namespace na Medicoweb.Data.Models.{nowy_projekt dla lekow lub aptek}")]
    public class PrescriptionDrug
    {
        public Guid Id { get; set; }
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public Guid DrugId { get; set; }
        public Drug Drug { get; set; }
        public int DrugQuantity { get; set; }
    }
}