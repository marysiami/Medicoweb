﻿using System.Collections.Generic;
using System.Linq;
using Medicoweb.Hospital.Models;

namespace Medicoweb.Web.ViewModels
{
    public class DepartamentListViewModel
    {
        public DepartamentListViewModel(DepartamentListing model)
        {
            TotalCount = model.TotalCount;
            Departaments = model.Departaments.Select(x => new DepartamentViewModel(x)).ToList();
            HospitalName = model.HospitalName;
        }

        public int TotalCount { get; set; }
        public List<DepartamentViewModel> Departaments { get; set; }
        public string HospitalName { get; set; }
    }
}