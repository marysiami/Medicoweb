﻿using SBD.DATA.Models;
using System;

namespace SBD.WEB.ViewModels
{
    public class PrescriptionViewModel
    {
        public Guid Id { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }

        public PrescriptionViewModel(Prescription model)
        {
            PatientName = model.Patient.Name;
            PatientSurname = model.Patient.Surname;
            DoctorName = model.Visit.Doctor.Name;
            DoctorSurname = model.Visit.Doctor.Surname;
        }

        
    }
}