using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.VISIT.Models
{
    public class VisitListing
    {
        public List<Visit> Visits { get; set; }
        public int TotalCount { get; set; }
        
    }
}
