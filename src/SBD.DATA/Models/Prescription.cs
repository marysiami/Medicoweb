using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.DATA.Models
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public Guid VisitId { get; set; }
        public Visit Visit { get; set; }
        public virtual ICollection<PrescriptionDrug> PrescriptionDrug { get; set; }
    }
}
