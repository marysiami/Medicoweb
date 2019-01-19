using Medicoweb.Data.Models;

namespace Medicoweb.Web.ViewModels
{
    public class DepartamentViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
       
        public DepartamentViewModel(Departament departament)
        {
            Id = departament.Id.ToString();
            Name = departament.Name;
        }
    }
}
