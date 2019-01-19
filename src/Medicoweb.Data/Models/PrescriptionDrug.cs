using System;

namespace Medicoweb.Data.Models
{
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