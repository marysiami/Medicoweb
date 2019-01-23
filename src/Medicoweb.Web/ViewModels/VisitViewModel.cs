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
            DateStart = visit.Start;
            HospitalName = visit.Hospital.Name;
            HospitalAddress = visit.Hospital.Address;
        }

        public string Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }

        public DateTime DateStart { get; set; }
    }
}