using Medicoweb.Data.Models;

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

        public string Id { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
    }
}