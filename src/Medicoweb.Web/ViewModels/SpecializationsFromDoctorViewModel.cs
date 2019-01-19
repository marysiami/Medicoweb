using Medicoweb.Data.Models;

namespace Medicoweb.Web.ViewModels
{
    public class SpecializationsFromDoctorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }


        public SpecializationsFromDoctorViewModel(SpecializationDoctor x)
        {
            Id = x.Id.ToString();
            Name = x.Specialization.Name;
        }
    }
}
