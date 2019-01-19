using System.Collections.Generic;
using Medicoweb.Data.Models;

namespace Medicoweb.Visit.Models
{
    public class PrescriptionListing
    {
        public List<Prescription> Prescriptions { get; set; }
        public int TotalCount { get; set; }
    }
}