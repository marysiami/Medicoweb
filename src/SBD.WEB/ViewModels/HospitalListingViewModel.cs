using SBD.HOSPITAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class HospitalListingViewModel
    {
        public int TotalCount { get; set; }
        public List<HospitalViewModel> Hospitals { get; set; }
        public HospitalListingViewModel(HospitalListing model)
        {
            TotalCount = model.TotalCount;
            Hospitals = model.Hospitals.Select(x => new HospitalViewModel(x)).ToList();
        }
    }
}
