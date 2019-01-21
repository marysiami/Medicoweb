using Medicoweb.Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicoweb.Web.ViewModels
{
    public class DepartamentDoctorsListViewModel
    {
        public string HospitalName { get; set; }
        public string DepartamentName { get; set; }
        public List<DoctorViewModel> Doctors { get; set; }
        public int TotalCount { get; set; }
        public DepartamentDoctorsListViewModel(DoctorListing doctorListing)
        {
            HospitalName = doctorListing.HospitalName;
            DepartamentName = doctorListing.DepartamentName;
            TotalCount = doctorListing.TotalCount;
            Doctors = doctorListing.Doctors.Select(x => new DoctorViewModel(x)).ToList();
        }
    }
}
