using Medicoweb.Data.Models;

namespace Medicoweb.Web.ViewModels
{
    public class SpecialityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    
        public SpecialityViewModel(Specialization x)
        {
            Id = x.Id.ToString();
            Name = x.Name;            
        }
    }
}
