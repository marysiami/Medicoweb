using System;

namespace Medicoweb.Data.Models.Hospital
{
    public class SpecializationDoctor
    {
        public Guid Id { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}