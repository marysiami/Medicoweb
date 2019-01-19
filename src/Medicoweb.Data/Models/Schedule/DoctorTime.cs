using System;

namespace Medicoweb.Data.Models.Schedule
{
    public class DoctorTime
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsCurrent { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}