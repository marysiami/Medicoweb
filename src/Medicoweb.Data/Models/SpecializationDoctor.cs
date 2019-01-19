using System;
using Medicoweb.Common.Attributes;

namespace Medicoweb.Data.Models
{
    [BadDesign("Zly namespace", "Przeniesc model do folderu Models/Hospital i zmienic namespace na Medicoweb.Data.Models.Hospital")]
    public class SpecializationDoctor
    {
        public Guid Id { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}