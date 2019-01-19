using Medicoweb.Data.Models;

namespace Medicoweb.Web.ViewModels
{
    public class DepartamentsFromDoctorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public DepartamentsFromDoctorViewModel(DepartamentDoctor x)
        {
            Id = x.Id.ToString();
            Name = x.Departament.Name;
        }
    }
}
