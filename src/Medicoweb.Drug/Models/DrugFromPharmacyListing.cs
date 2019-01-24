using Medicoweb.Data.Models.Drug;
using System.Collections.Generic;

namespace Medicoweb.Drug.Models
{
    public class DrugFromPharmacyListing
    {
        public List<PharmacyDrug> Drugs { get; set; }
        public int TotalCount { get; set; }
        public string PharmacyName { get; set; }
    
    }
}
