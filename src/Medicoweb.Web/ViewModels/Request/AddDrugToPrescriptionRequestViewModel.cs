namespace Medicoweb.Web.ViewModels.Request
{
    public class AddDrugToPrescriptionRequestViewModel
    {
    
        public string DrugId { get; set; }
        public int DrugQuantity { get; set; }
        public string PrescriptionId { get; set; }
    }
}