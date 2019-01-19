using System.Collections.Generic;
using Medicoweb.Data.Models;

namespace Medicoweb.Hospital.Models
{
    public class SpecializationListing
    {
        public List<Specialization> Specialization { get; set; }
        public int TotalCount { get; set; }
    }
}