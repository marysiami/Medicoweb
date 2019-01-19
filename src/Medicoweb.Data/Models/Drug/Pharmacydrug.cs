using System;

namespace Medicoweb.Data.Models.Drug
{
    public class PharmacyDrug
    {
        public Guid Id { get; set; }
        public Guid PharmacyId { get; set; }
        public Guid DrugId { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
    }
}