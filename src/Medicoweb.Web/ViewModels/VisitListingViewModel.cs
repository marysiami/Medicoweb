using System.Collections.Generic;
using System.Linq;
using Medicoweb.Visit.Models;

namespace Medicoweb.Web.ViewModels
{
    public class VisitListingViewModel
    {
        public VisitListingViewModel(VisitListing model)
        {            
            Visits = model.Visits.Select(x => new VisitViewModel(x)).ToList();
        }
               
        public List<VisitViewModel> Visits { get; set; }
    }
}