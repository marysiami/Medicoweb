using Medicoweb.Data.Models.Hospital;
using System.Collections.Generic;

namespace Medicoweb.Hospital.Models
{
    public class SpecializationListing
    {
        public List<Specialization> Specialization { get; set; }
        public int TotalCount { get; set; }
    }
}