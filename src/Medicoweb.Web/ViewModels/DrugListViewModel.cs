using Medicoweb.Drug.Models;
using System.Collections.Generic;
using System.Linq;

namespace Medicoweb.Web.ViewModels
{
    public class DrugListViewModel
    {
        public DrugListViewModel(DrugListing model)
        {
            TotalCount = model.TotalCount;
            Drugs = model.Drugs.Select(x => new DrugViewModel(x)).ToList();
        }

        public int TotalCount { get; set; }
        public List<DrugViewModel> Drugs { get; set; }
    }
}