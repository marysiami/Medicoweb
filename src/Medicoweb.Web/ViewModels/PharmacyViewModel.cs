using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicoweb.Web.ViewModels
{
    public class PharmacyViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public PharmacyViewModel(Data.Models.Drug.Pharmacy pharmacy)
        {
            Id = pharmacy.Id.ToString();
            Name = pharmacy.Name;
            Address = pharmacy.Address;
        }
    }
}
