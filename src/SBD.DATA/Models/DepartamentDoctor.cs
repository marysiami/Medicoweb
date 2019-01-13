using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.DATA.Models
{
    public class DepartamentDoctor
    {
        public Guid Id { get; set; }
        public Guid DepartamentId { get; set; }
        public Guid DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Departament Departament { get; set; }
    }
}
