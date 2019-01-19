using System.Collections.Generic;
using System.Linq;
using Medicoweb.Hospital.Models;

namespace Medicoweb.Web.ViewModels
{
    public class DepartamentsFromDoctorLisingViewModel
    {
        public DepartamentsFromDoctorLisingViewModel(DoctorDepartamentListing model)
        {
            TotalCount = model.Departaments.Count;
            DoctorName = model.Name;
            DoctorSurname = model.Surname;
            Departaments = model.Departaments.Select(x => new DepartamentsFromDoctorViewModel(x)).ToList();
        }

        public int TotalCount { get; set; }
        public List<DepartamentsFromDoctorViewModel> Departaments { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
    }
}