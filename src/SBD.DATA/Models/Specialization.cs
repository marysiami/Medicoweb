﻿using System;
using System.Collections.Generic;

namespace SBD.DATA.Models
{
    public class Specialization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SpecializationDoctor> SpecializationDoctor { get; set; }
    }
}