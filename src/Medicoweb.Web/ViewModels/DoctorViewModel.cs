using Medicoweb.Data.Models.Hospital;

namespace Medicoweb.Web.ViewModels
{
    public class DoctorViewModel
    {
        public DoctorViewModel(Doctor x)
        {
            Id = x.Id.ToString();
            Name = x.Name;
            Surname = x.Surname;
            Pesel = x.Pesel;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
    }
}