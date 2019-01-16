using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class DepartamentsFromDoctorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public DepartamentsFromDoctorViewModel(DepartamentDoctor x)
        {
            Id = x.Id.ToString();
            Name = x.Departament.Name;
        }
    }
}
