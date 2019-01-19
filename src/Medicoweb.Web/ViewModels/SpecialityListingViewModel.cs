using System.Collections.Generic;
using System.Linq;
using Medicoweb.Hospital.Models;

namespace Medicoweb.Web.ViewModels
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
