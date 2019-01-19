using System.Linq;

namespace Medicoweb.Web.ViewModels
{
    public class HospitalViewModel
    {
        public HospitalViewModel(Data.Models.Hospital x)
        {
            Id = x.Id.ToString();
            Name = x.Name;
            Address = x.Address;
            RepliesCount = x.Departaments == null ? 0 : x.Departaments.Count();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int RepliesCount { get; set; }
        public string Address { get; set; }
    }
}