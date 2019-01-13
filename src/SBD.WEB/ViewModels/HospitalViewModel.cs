using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD.WEB.ViewModels
{
    public class HospitalViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RepliesCount { get; set; }
        public string Address { get; set; }
        public HospitalViewModel(Hospital x)
        {
            Id = x.Id.ToString();
            Name = x.Name;
            Address = x.Address; 
            RepliesCount = x.Departaments == null ? 0 : x.Departaments.Count();
            
        }
    }
}
