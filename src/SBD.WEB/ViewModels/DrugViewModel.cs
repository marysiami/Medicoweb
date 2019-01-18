using SBD.DATA.Models;

namespace SBD.WEB.ViewModels
{
    public class DrugViewModel
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public DrugViewModel(Drug model)
        {
            Company = model.Company;
            Name = model.Name;
            Id = model.Id.ToString();
        }
    }
}
