using System.Collections.Generic;
using System.Linq;
using Medicoweb.Visit.Models;

namespace Medicoweb.Web.ViewModels
{
    public class PrescriptionListingViewModel
    {
        public PrescriptionListingViewModel(PrescriptionListing model)
        {
            TotalCount = model.TotalCount;
            Prescriptions = model.Prescriptions.Select(x => new PrescriptionViewModel(x)).ToList();
        }

        public int TotalCount { get; set; }
        public List<PrescriptionViewModel> Prescriptions { get; set; }
    }
}