using Medicoweb.Data.Models.Drug;
using Medicoweb.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medicoweb.Pharmacy.Contracts
{
    public interface IPharmacyService
    {
        Task<Data.Models.Drug.Pharmacy> CreatePharmacy(string name, string address);
        Task<Data.Models.Drug.Pharmacy> GetPharmacyById(string id);
        PharmacyListing GetPharmacies(int skip = 0, int take = 10);
        Task DeletePharmacy(string id);
        Task UpdatePharmacyAsync(string id, string name, string address);
        Task AddDrugToPharmacy(Data.Models.Drug.Pharmacy pharmacy, Drug drug);
        Task RemoveDrugFromPharmacyAsync(Data.Models.Drug.Pharmacy pharmacy, Drug drug);
        
    }
}
