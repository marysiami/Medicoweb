using SBD.DATA.Models;

namespace SBD.WEB.ViewModels
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
