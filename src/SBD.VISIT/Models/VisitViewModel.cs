using SBD.DATA.Models.Schedule;
using System;

namespace SBD.VISIT.Models
{
    public class VisitViewModel
    {
        public Guid PatientId { get; set; }     
        public Guid DoctorId { get; set; }        
        public VisitTime VisitDate { get; set; }
    }
}
