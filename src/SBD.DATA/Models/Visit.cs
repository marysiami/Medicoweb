using SBD.DATA.Models.Account;
using SBD.DATA.Models.Schedule;
using System;
using System.Collections.Generic;

namespace SBD.DATA.Models
{
    public class Visit
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public virtual SBDUser Patient { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual VisitTime Date { get; set; }
        public bool IsCancelled { get; set; }

        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
