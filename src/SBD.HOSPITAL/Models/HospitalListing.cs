using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.HOSPITAL.Models
{
    public class HospitalListing
    {
        public List<Hospital> Hospitals { get; set; }
        public int TotalCount { get; set; }
    }
}
