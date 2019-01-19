using System.Collections.Generic;
using Medicoweb.Data.Models;

namespace Medicoweb.Visit.Models
{
    public class DrugsFromPrescriptionListing
    {
        public List<PrescriptionDrug> Drugs { get; set; }
        public int TotalCount { get; set; }
    }
}