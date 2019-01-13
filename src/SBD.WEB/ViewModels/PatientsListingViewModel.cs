using SBD.HOSPITAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class PatientsListingViewModel
    {
        public int TotalCount { get; set; }
        public List<PatientViewModel> Patients { get; set; }
        public PatientsListingViewModel(PatientListing model)
        {
            TotalCount = model.TotalCount;
            Patients = model.Patients.Select(x => new PatientViewModel(x)).ToList();
        }
    }
}
