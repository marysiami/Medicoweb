using Medicoweb.Data.Models;
using Medicoweb.Data.Models.Drug;

namespace Medicoweb.Web.ViewModels
{
    public class DrugViewModel
    {
        public DrugViewModel(Data.Models.Drug.Drug model)
        {
            Company = model.Company;
            Name = model.Name;
            Id = model.Id.ToString();
        }
        public DrugViewModel(PharmacyDrug model)
        {
            Company = model.Drug.Company;
            Name = model.Drug.Name;
            Id = model.Drug.Id.ToString();
        }

        public string Id { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        
    }
}