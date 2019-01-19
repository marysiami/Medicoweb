using Medicoweb.Data.Models.Visit;
using System.Collections.Generic;

namespace Medicoweb.Visit.Models
{
    public class PrescriptionListing
    {
        public List<Prescription> Prescriptions { get; set; }
        public int TotalCount { get; set; }
    }
}