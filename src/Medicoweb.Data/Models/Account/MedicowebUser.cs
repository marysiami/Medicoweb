using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Medicoweb.Data.Models.Account
{
    public class MedicowebUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}