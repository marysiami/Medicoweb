using Medicoweb.Data.Models.Account;

namespace Medicoweb.Web.ViewModels
{
    public class PatientViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }

        public PatientViewModel(SBDUser x)
        {
            Id = x.Id.ToString();
            Name = x.Name;
            Surname = x.Surname;
            Pesel = x.Pesel;

        }

    }
}
