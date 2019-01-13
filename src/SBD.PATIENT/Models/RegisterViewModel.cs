using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.PATIENT.Models
{
    public class RegisterViewModel
    {
        public string Pesel { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
