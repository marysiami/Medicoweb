using Medicoweb.Data.Models.Hospital;

namespace Medicoweb.Web.ViewModels
{
    public class DepartamentViewModel
    {
        public DepartamentViewModel(Departament departament)
        {
            Id = departament.Id.ToString();
            Name = departament.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}