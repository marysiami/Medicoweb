using SBD.HOSPITAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class DepartamentListViewModel
    {
        public int TotalCount { get; set; }
        public List<DepartamentViewModel> Departaments { get; set; }
        public string HospitalName { get; set; }
        public DepartamentListViewModel(DepartamentListing model)
        {
            TotalCount = model.TotalCount;
            Departaments = model.Departaments.Select(x => new DepartamentViewModel(x)).ToList();
            HospitalName = model.HospitalName;
        }
    }
}
