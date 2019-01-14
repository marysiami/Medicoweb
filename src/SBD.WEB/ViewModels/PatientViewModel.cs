﻿using SBD.DATA.Models;
using SBD.DATA.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class PatientViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }

        public PatientViewModel(SBDUser x)
        {
            Id = x.Id.ToString();
            Name = x.Name;
            Surname = x.Surname;
            Pesel = x.Pesel;

        }

    }
}
