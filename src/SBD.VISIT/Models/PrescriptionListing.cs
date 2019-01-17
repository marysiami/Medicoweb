using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.VISIT.Models
{
    public class PrescriptionListing
    {
        public List<Prescription> Prescriptions { get; set; }
        public int TotalCount { get; set; }
    }
}
