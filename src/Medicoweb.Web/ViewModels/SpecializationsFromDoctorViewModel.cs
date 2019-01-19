using Medicoweb.Data.Models;

namespace Medicoweb.Web.ViewModels
{
    public class SpecializationsFromDoctorViewModel
    {
        public SpecializationsFromDoctorViewModel(SpecializationDoctor x)
        {
            Id = x.Id.ToString();
            Name = x.Specialization.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}