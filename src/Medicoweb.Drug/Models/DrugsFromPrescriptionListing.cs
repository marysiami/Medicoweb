using Medicoweb.Data.Models.Drug;
using System.Collections.Generic;

namespace Medicoweb.Drug.Models
{
    public class DrugsFromPrescriptionListing
    {
        public List<PrescriptionDrug> Drugs { get; set; }
        public int TotalCount { get; set; }
    }
}