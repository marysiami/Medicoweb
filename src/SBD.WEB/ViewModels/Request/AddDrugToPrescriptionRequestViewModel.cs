namespace SBD.WEB.ViewModels.Request
{
    public class AddDrugToPrescriptionRequestViewModel
    {
        public string PrescriptionId { get; set; }
        public string DrugId { get; set; }
        public int QuantityDrug { get; set; }
    }
}
