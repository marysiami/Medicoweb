using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels.Request
{
    public class CreateVisitRequestViewModel
    {
        public string HospitalId { get; set; }
        public string DepartamentId { get; set; }
        public string DoctorId { get; set; }
        public string SBDUserId { get; set; }
        public TimeSpan VisitStart { get; set; }

    }
}
