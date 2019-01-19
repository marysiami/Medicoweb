﻿using System;
using System.Collections.Generic;
using Medicoweb.Common.Attributes;
using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Schedule;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/Visit i zmienic namespace na Medicoweb.Data.Models.Visit")]
    public class Visit
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public virtual MedicowebUser Patient { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual VisitTime Date { get; set; }
        public bool IsCancelled { get; set; }

        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}