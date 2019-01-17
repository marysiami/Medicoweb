using SBD.DATA.Models.Account;
using System;
using System.Collections.Generic;

namespace SBD.DATA.Models
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public Guid VisitId { get; set; }
        public Visit Visit { get; set; }
        public Guid PatientId { get; set; }
        public SBDUser Patient { get; set; }
        public virtual ICollection<PrescriptionDrug> PrescriptionDrug { get; set; }
    }
}
