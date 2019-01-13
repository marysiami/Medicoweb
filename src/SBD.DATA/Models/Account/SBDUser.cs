using Microsoft.AspNetCore.Identity;
using System;

namespace SBD.DATA.Models.Account
{
    public class SBDUser : IdentityUser<Guid>
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        
      
    }
}
