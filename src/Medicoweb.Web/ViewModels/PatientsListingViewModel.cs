using System.Collections.Generic;
using System.Linq;
using Medicoweb.Hospital.Models;

namespace Medicoweb.Web.ViewModels
{
    public class PatientsListingViewModel
    {
        public PatientsListingViewModel(PatientListing model)
        {
            TotalCount = model.TotalCount;
            Patients = model.Patients.Select(x => new PatientViewModel(x)).ToList();
        }

        public int TotalCount { get; set; }
        public List<PatientViewModel> Patients { get; set; }
    }
}