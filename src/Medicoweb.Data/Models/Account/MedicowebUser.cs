using System;
using System.Collections.Generic;
using Medicoweb.Data.Models.Visit;
using Microsoft.AspNetCore.Identity;

namespace Medicoweb.Data.Models.Account
{
    public class MedicowebUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Visit.Visit> Visits { get; set; }
    }
}