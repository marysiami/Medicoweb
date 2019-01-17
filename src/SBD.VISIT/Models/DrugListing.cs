using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.VISIT.Models
{
    public class DrugListing
    {
        public List<Drug> Drugs { get; set; }
        public int TotalCount { get; set; }
    }
}
