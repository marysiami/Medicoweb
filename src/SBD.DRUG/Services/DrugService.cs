using Microsoft.EntityFrameworkCore;
using SBD.DATA.Contracts;
using SBD.DATA.Models;
using SBD.DRUG.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBD.DRUG.Services
{
    public class DrugService : IDrugService
    {
        private readonly IDataService _dataService;
        public DrugService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Drug> CreateDrug(string name, string company, bool isPrescriptionNeeded)
        {
            var newDrug = new Drug
            {
                Name = name,
                Company = company,
                IsPrescriptionNeeded = isPrescriptionNeeded                
            };
            await _dataService.GetSet<Drug>().AddAsync(newDrug);
            await _dataService.SaveDbAsync();

            return newDrug;
        }

        public async Task DeleteDrug(string id)
        {
            var set = _dataService.GetSet<Drug>();
            var drug = await set.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            set.Remove(drug);
            await _dataService.SaveDbAsync();
        }

        public Task<List<Drug>> GetDrugsFromRec(string id)
        {
            throw new NotImplementedException();
            //po dodaniu recepty
        }

        public async Task<Drug> GetDrug(string id)
        {
            return await _dataService.GetSet<Drug>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }

        public async Task<List<Drug>> GetDrugs()
        {
            return await _dataService.GetSet<Drug>().ToListAsync();
        }

        public async Task<List<Drug>> GetDrugsFromPharm(string id)
        {
            var set = _dataService.GetSet<Pharmacy>();
            var pharmacy = await set.Include(x => x.PharmacyDrugs).ThenInclude(y => y.DrugId)
                .FirstOrDefaultAsync(x => x.Id.ToString() == id);
            var drugs = pharmacy.PharmacyDrugs.Select(x => x.Drug).ToList();

            return drugs;

        }
    }
}
