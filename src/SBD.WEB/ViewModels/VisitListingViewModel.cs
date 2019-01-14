using SBD.VISIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class VisitListingViewModel
    {
        public int TotalCount { get; set; }
        public List<VisitViewModel> Visits { get; set; }
        public VisitListingViewModel(VisitListing model)
        {
            TotalCount = model.TotalCount;
            Visits = model.Visits.Select(x => new VisitViewModel(x)).ToList();
        }
    }
}
