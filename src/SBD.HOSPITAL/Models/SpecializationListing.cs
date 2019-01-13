using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.HOSPITAL.Models
{
    public class SpecializationListing
    {
        public List<Specialization> Specialization { get; set; }
        public int TotalCount { get; set; }       
    }
}
