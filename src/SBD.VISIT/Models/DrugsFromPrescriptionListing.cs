using SBD.DATA.Models;
using System.Collections.Generic;

namespace SBD.VISIT.Models
{
    public class DrugsFromPrescriptionListing
    {
        public List<PrescriptionDrug> Drugs { get; set; }
        public int TotalCount { get; set; }
    }
}
