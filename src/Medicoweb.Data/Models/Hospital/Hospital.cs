﻿using System;
using System.Collections.Generic;

namespace Medicoweb.Data.Models.Hospital
{
    public class Hospital
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Departament> Departaments { get; set; }
        public virtual ICollection<Visit.Visit> Visits { get; set; }
    }
}