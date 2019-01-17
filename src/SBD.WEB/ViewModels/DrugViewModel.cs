using SBD.DATA.Models;

namespace SBD.WEB.ViewModels
{
    public class DrugViewModel
    {
        public string Company { get; set; }
        public string Name { get; set; }
        public DrugViewModel(Drug model)
        {
            Company = model.Company;
            Name = model.Name;
        }
    }
}
