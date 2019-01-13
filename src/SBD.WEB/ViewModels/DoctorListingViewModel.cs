using SBD.HOSPITAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class DoctorListingViewModel
    {
        public int TotalCount { get; set; }
        public List<DoctorViewModel> Doctors { get; set; }
        public DoctorListingViewModel(DoctorListing model)
        {
            TotalCount = model.TotalCount;
            Doctors = model.Doctors.Select(x => new DoctorViewModel(x)).ToList();
        }
    }
}
