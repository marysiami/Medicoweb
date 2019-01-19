using System;
using Medicoweb.Data.Models;

namespace Medicoweb.Web.ViewModels
{
    public class DrugsFromPrescriptionViewModel
    {
        public Guid Id { get; set; }
        public string DrugName { get; set; }
        public string DrugCompny { get; set; }
        public int DrugQuantity { get; set; }
       

        public DrugsFromPrescriptionViewModel( PrescriptionDrug model)
        {
            DrugName = model.Drug.Name;
            DrugCompny = model.Drug.Company;
            DrugQuantity = model.DrugQuantity;           
        }
    }
}
