using System;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/Hospital i zmienic namespace na Medicoweb.Data.Models.Hospital")]
    public class DepartamentDoctor
    {
        public Guid Id { get; set; }
        public Guid DepartamentId { get; set; }
        public Guid DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Departament Departament { get; set; }
    }
}