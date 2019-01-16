using SBD.HOSPITAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SBD.WEB.ViewModels
{
    public class SpecialityListingViewModel
    {
        public int TotalCount { get; set; }
        public List<SpecialityViewModel> Specialization { get; set; }
        public SpecialityListingViewModel(SpecializationListing model)
        {
            TotalCount = model.TotalCount;
            Specialization = model.Specialization.Select(x => new SpecialityViewModel(x)).ToList();
        }
      
    }
}
