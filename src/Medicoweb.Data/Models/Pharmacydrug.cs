using System;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/{nowy_projekt dla lekow lub aptek} i zmienic namespace na Medicoweb.Data.Models.{nowy_projekt dla lekow lub aptek}")]
    public class PharmacyDrug
    {
        public Guid Id { get; set; }
        public Guid PharmacyId { get; set; }
        public Guid DrugId { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
    }
}