using System;

namespace Medicoweb.Web.ViewModels.Request
{
    public class CreatePrescriptionRequestViewModel
    {
        public Guid Id { get; set; }   
        public String PatientName { get; set; }
        public string PatientSurname { get; set; }
        public String PDoctortName { get; set; }
        public string DoctorSurname { get; set; }      
        public string VisitId { get; set; }
    }
}
