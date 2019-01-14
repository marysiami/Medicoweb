using System;

namespace SBD.DATA.Models.Schedule
{
    public class VisitTime
    {
        public Guid Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Visit Visit { get; set; }
        public Guid VisitId { get; set; }
    }
}
