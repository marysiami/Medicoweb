using System.Collections.Generic;

namespace Medicoweb.Visit.Models
{
    public class VisitListing
    {
        public List<Data.Models.Visit> Visits { get; set; }
        public int TotalCount { get; set; }
        
    }
}
