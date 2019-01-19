using System.Collections.Generic;
using Medicoweb.Data.Models;

namespace Medicoweb.Visit.Models
{
    public class DrugListing
    {
        public List<Drug> Drugs { get; set; }
        public int TotalCount { get; set; }
    }
}
