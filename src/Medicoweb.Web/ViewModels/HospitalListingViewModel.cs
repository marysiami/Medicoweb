using System.Collections.Generic;
using System.Linq;
using Medicoweb.Hospital.Models;

namespace Medicoweb.Web.ViewModels
{
    public class HospitalListingViewModel
    {
        public HospitalListingViewModel(HospitalListing model)
        {
            TotalCount = model.TotalCount;
            Hospitals = model.Hospitals.Select(x => new HospitalViewModel(x)).ToList();
        }

        public int TotalCount { get; set; }
        public List<HospitalViewModel> Hospitals { get; set; }
    }
}