using System.Collections.Generic;

namespace Medicoweb.Drug.Models
{
    public class DrugListing
    {
        public List<Data.Models.Drug.Drug> Drugs { get; set; }
        public int TotalCount { get; set; }
    }
}