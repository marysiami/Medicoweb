using Medicoweb.Data.Models.Drug;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medicoweb.Visit.Models
{
    public class DrugListingFromPrescription
    {
        public List<PrescriptionDrug> Drugs { get; set; }
        public int TotalCount { get; set; }
    }
}
