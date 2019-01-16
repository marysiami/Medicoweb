using SBD.HOSPITAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class SpecializationsFromDepartamentListingViewModel
    {
        public int TotalCount { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public List<SpecializationsFromDoctorViewModel> Specializations { get; set; }

        public SpecializationsFromDepartamentListingViewModel(DoctorSpecListing model)
        {
            TotalCount = model.Specializations.Count;
            DoctorName = model.Name;
            DoctorSurname = model.Surname;
            Specializations = model.Specializations.Select(x => new SpecializationsFromDoctorViewModel(x)).ToList();

        }
    }
}
