using System.Linq;
using System.Threading.Tasks;
using Medicoweb.Data.Contracts;
using Medicoweb.Data.Models.Drug;
using Medicoweb.Pharmacy.Contracts;
using Medicoweb.Pharmacy.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicoweb.Pharmacy.Services
{
    public class PharmacyService : IPharmacyService
    {

        private readonly IDataService _dataService;
        public PharmacyService(IDataService dataService)
        {
            _dataService = dataService;
        }


        public async Task AddDrugToPharmacy(Data.Models.Drug.Pharmacy pharmacy, Drug drug)
        {
            var model = new PharmacyDrug
            {
                Pharmacy = pharmacy,
                PharmacyId = pharmacy.Id,
                Drug = drug,
                DrugId = drug.Id
            };
            _dataService.GetSet<PharmacyDrug>().Add(model);
            await _dataService.SaveDbAsync();
        }

        public async Task<Data.Models.Drug.Pharmacy> CreatePharmacy(string name, string address)
        {
            var model = new Data.Models.Drug.Pharmacy
            {
                Name = name,
                Address = address
            };
             _dataService.GetSet<Data.Models.Drug.Pharmacy>().Add(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public async Task DeletePharmacy(string id)
        {
            var model = await GetPharmacyById(id);

            _dataService.GetSet<Data.Models.Drug.Pharmacy>().Remove(model);

            await _dataService.SaveDbAsync();
        }

        public PharmacyListing GetPharmacies(int skip = 0, int take = 10)
        {
            var model = new PharmacyListing
            {
                Pharmacies = _dataService.GetSet<Data.Models.Drug.Pharmacy>()
                    .Skip(skip * take)
                    .Take(take)
                    .ToList()
            };

            return model;
        }

        public async Task<Data.Models.Drug.Pharmacy> GetPharmacyById(string id)
        {
            var model = await _dataService.GetSet<Data.Models.Drug.Pharmacy>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public async Task RemoveDrugFromPharmacyAsync(Data.Models.Drug.Pharmacy pharmacy, Drug drug)
        {
            var model = _dataService.GetSet<PharmacyDrug>().Where(x => x.Drug == drug).FirstOrDefault(x => x.Pharmacy == pharmacy);

            _dataService.GetSet<PharmacyDrug>().Remove(model);

            await _dataService.SaveDbAsync();
        }

        public async Task UpdatePharmacyAsync(string id, string name, string address)
        {
            var model = await GetPharmacyById(id);
            model.Name = name;
            model.Address = address;

            _dataService.GetSet<Data.Models.Drug.Pharmacy>().Update(model);

            await _dataService.SaveDbAsync();
        }
    }
    
}
