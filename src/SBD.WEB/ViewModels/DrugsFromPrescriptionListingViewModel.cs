using SBD.VISIT.Models;
using System.Collections.Generic;
using System.Linq;

namespace SBD.WEB.ViewModels
{
    public class DrugsFromPrescriptionListingViewModel
    {
        public int TotalCount { get; set; }
        public List<DrugsFromPrescriptionViewModel> Drugs { get; set; }
        public DrugsFromPrescriptionListingViewModel(DrugsFromPrescriptionListing model)
        {
            TotalCount = model.TotalCount;
            Drugs = model.Drugs.Select(x => new DrugsFromPrescriptionViewModel(x)).ToList();
        }
    }
}
