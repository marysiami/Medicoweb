using Medicoweb.Data.Models.Hospital;

namespace Medicoweb.Web.ViewModels
{
    public class DepartamentsFromDoctorViewModel
    {
        public DepartamentsFromDoctorViewModel(Departament x)
        {
            Id = x.Id.ToString();
            Name = x.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}