﻿using System.Collections.Generic;
using System.Linq;
using Medicoweb.Hospital.Models;

namespace Medicoweb.Web.ViewModels
{
    public class DoctorListingViewModel
    {
        public DoctorListingViewModel(DoctorListing model)
        {
            TotalCount = model.TotalCount;
            Doctors = model.Doctors.Select(x => new DoctorViewModel(x)).ToList();
        }

        public int TotalCount { get; set; }
        public List<DoctorViewModel> Doctors { get; set; }
        public string SpecializationName { get; set; }
    }
}