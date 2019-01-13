using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.DATA.Models
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
