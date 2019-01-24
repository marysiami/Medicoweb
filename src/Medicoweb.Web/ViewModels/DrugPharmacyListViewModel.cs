using Medicoweb.Drug.Models;
using System.Collections.Generic;
using System.Linq;

namespace Medicoweb.Web.ViewModels
{
    public class DrugPharmacyListViewModel
    {

        public DrugPharmacyListViewModel(DrugFromPharmacyListing model)
        {
            TotalCount = model.TotalCount;
            Drugs = model.Drugs.Select(x => new DrugViewModel(x)).ToList();
            PharmacyName = model.PharmacyName;
        }

        public int TotalCount { get; set; }
        public List<DrugViewModel> Drugs { get; set; }
        public string PharmacyName { get; set; }
    }
}
