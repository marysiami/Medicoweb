using Medicoweb.Pharmacy.Models;
using System.Collections.Generic;
using System.Linq;

namespace Medicoweb.Web.ViewModels
{
    public class PharmacyListViewModel
    {
       
        public List <PharmacyViewModel> Pharmacies { get; set; }

        public PharmacyListViewModel(PharmacyListing pharmacy)
        {
          
            Pharmacies = pharmacy.Pharmacies.Select(x => new PharmacyViewModel(x)).ToList();
        }
    }
}
