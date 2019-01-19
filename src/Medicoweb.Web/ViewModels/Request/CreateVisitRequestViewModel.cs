using System;

namespace Medicoweb.Web.ViewModels.Request
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
