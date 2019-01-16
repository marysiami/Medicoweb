using SBD.HOSPITAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels.Request
{
    public class DepartamentsFromDoctorLisingViewModel
    {
        public int TotalCount { get; set; }
        public List<DepartamentsFromDoctorViewModel> Departaments { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }

        public DepartamentsFromDoctorLisingViewModel(DoctorDepartamentListing model)
        {
            TotalCount = model.Departaments.Count;
            DoctorName = model.Name;
            DoctorSurname = model.Surname;
            Departaments = model.Departaments.Select(x => new DepartamentsFromDoctorViewModel(x)).ToList();
            
        }
    }
}
