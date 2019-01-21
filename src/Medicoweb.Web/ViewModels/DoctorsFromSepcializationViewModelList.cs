using Medicoweb.Data.Models.Hospital;
using Medicoweb.Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicoweb.Web.ViewModels
{
    public class DoctorsFromSepcializationViewModelList
    {
       
        public DoctorsFromSepcializationViewModelList(DoctorFromSpecListing model)
        {
            this.SpecializationName = model.SpecializationName;
            this.TotalCount = model.TotalCount;
            this.Doctors = model.Doctors.Select(x => new DoctorViewModel(x)).ToList();

        }

        public string SpecializationName { get; set; }
        public int TotalCount {get;set;}
        public List<DoctorViewModel> Doctors { get; set; }

    }
}
