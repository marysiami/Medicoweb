using System;

namespace Medicoweb.Web.ViewModels
{
    public class VisitViewModel
    {
        public VisitViewModel(Data.Models.Visit.Visit visit)
        {
            Id = visit.Id.ToString();
            DoctorName = visit.Doctor.Name;
            DoctorSurname = visit.Doctor.Surname;
            PatientName = visit.Patient.Name;
            PatientSurname = visit.Patient.Surname;
            DateStart = visit.Date.StartTime;
        }

        public string Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }

        public TimeSpan DateStart { get; set; }
    }
}