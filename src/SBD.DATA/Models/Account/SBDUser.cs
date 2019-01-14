using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SBD.DATA.Models.Account
{
    public class SBDUser : IdentityUser<Guid>
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

    }
}
