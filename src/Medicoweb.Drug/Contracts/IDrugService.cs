using Medicoweb.Data.Models.Drug;
using Medicoweb.Data.Models.Visit;
using Medicoweb.Drug.Models;
using System.Threading.Tasks;

namespace Medicoweb.Drug.Contracts
{
    public interface IDrugService
    {
        Task<Data.Models.Drug.Drug> CreateDrugAsync(string name, string company);
        Task<Data.Models.Drug.Drug> GetDrugById(string id);
        DrugListing GetDrugs(int skip = 0, int take = 10);
        Task DeleteDrug(string id);
        Task UpdateDrug(string id, string name, string company);
        DrugFromPharmacyListing GetDrugsFromPharmacy(Pharmacy pharmacy, int skip = 0, int take = 10);
        Task RemoveDrugFromPharmacy(Pharmacy pharmacy, Data.Models.Drug.Drug drug);


    }
}

