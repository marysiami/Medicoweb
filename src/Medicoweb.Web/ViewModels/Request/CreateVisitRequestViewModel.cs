using System;

namespace Medicoweb.Web.ViewModels.Request
{
    public class CreateVisitRequestViewModel
    {
        public string HospitalId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public string Date { get; set; }
    }
}