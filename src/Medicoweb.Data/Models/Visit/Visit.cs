using System;
using System.Collections.Generic;
using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Hospital;


namespace Medicoweb.Data.Models.Visit
{
    public class Visit
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public virtual MedicowebUser Patient { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public  DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Guid HospitalId { get; set; }
        public Hospital.Hospital Hospital{ get; set; }

        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}