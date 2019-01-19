using Medicoweb.Data.Models.Account;

namespace Medicoweb.Web.ViewModels
{
    public class PatientViewModel
    {
        public PatientViewModel(MedicowebUser x)
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