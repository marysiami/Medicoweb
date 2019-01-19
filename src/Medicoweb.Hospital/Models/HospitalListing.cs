using System.Collections.Generic;

namespace Medicoweb.Hospital.Models
{
    public class HospitalListing
    {
        public List<Data.Models.Hospital> Hospitals { get; set; }
        public int TotalCount { get; set; }
    }
}
