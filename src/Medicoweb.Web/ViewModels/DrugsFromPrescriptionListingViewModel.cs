using System.Collections.Generic;
using System.Linq;
using Medicoweb.Visit.Models;

namespace Medicoweb.Web.ViewModels
{
    public class DrugsFromPrescriptionListingViewModel
    {
        public DrugsFromPrescriptionListingViewModel(DrugsFromPrescriptionListing model)
        {
            TotalCount = model.TotalCount;
            Drugs = model.Drugs.Select(x => new DrugsFromPrescriptionViewModel(x)).ToList();
        }

        public int TotalCount { get; set; }
        public List<DrugsFromPrescriptionViewModel> Drugs { get; set; }
    }
}