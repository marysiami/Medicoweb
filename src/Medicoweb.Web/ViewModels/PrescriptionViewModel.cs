using Medicoweb.Data.Models.Visit;
using System;

namespace Medicoweb.Web.ViewModels
{
    public class PrescriptionViewModel
    {
        public PrescriptionViewModel(Prescription model)
        {
            Id = model.Id;
            PatientName = model.Visit.Patient.Name;
            PatientSurname = model.Visit.Patient.Surname;
            DoctorName = model.Visit.Doctor.Name;
            DoctorSurname = model.Visit.Doctor.Surname;
        }

        public Guid Id { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
       
    }
}