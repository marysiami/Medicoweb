using System.Collections.Generic;
using System.Linq;
using Medicoweb.Visit.Models;

namespace Medicoweb.Web.ViewModels
{
    public class DrugListViewModel
    {
        public int TotalCount { get; set; }
        public List<DrugViewModel> Drugs { get; set; }
       
        public DrugListViewModel(DrugListing model)
        {
            TotalCount = model.TotalCount;
            Drugs = model.Drugs.Select(x => new DrugViewModel(x)).ToList();
          
        }
    }
}
