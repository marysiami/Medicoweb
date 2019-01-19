using System.Linq;
using System.Threading.Tasks;
using Medicoweb.Data.Contracts;
using Medicoweb.Data.Models;
using Medicoweb.Data.Models.Drug;
using Medicoweb.Data.Models.Visit;
using Medicoweb.Drug.Contracts;
using Medicoweb.Drug.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicoweb.Drug.Services
{
    public class DrugService : IDrugService
    {
        private readonly IDataService _dataService;
      

        public DrugService(IDataService dataService)
        {
            _dataService = dataService;           
        }

        public async Task<PrescriptionDrug> AddDrugToPrescriptionAsync(Prescription prescription, Data.Models.Drug.Drug drug, int drugQuantity)
        {
            var model = new PrescriptionDrug
            {
                DrugId = drug.Id,
                Drug = drug,
                PrescriptionId = prescription.Id,
                Prescription = prescription,
                DrugQuantity = drugQuantity
            };
            await _dataService.GetSet<PrescriptionDrug>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public async Task<Data.Models.Drug.Drug> CreateDrugAsync(string name, string company)
        {
            var model = new Data.Models.Drug.Drug
            {
                Name = name,
                Company = company
            };
            await _dataService.GetSet<Data.Models.Drug.Drug>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public async Task DeleteDrug(string id)
        {
            var model = await GetDrugById(id);

            _dataService.GetSet<Data.Models.Drug.Drug>().Remove(model);

            await _dataService.SaveDbAsync();
        }

        public async Task<Data.Models.Drug.Drug> GetDrugById(string id)
        {
            var model = await _dataService.GetSet<Data.Models.Drug.Drug>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }

        public DrugListing GetDrugs(int skip = 0, int take = 10)
        {
            var model = new DrugListing
            {
                TotalCount = _dataService.GetSet<Data.Models.Drug.Drug>().Count(),
                Drugs = _dataService.GetSet<Data.Models.Drug.Drug>().Skip(skip * take)
                   .Take(take)
                   .ToList()
            };

            return model;
        }

        public  async Task UpdateDrug(string id, string name, string company)
        {

            var model = await GetDrugById(id);
            model.Name = name;
            model.Company = company;

            _dataService.GetSet<Data.Models.Drug.Drug>().Update(model);

            await _dataService.SaveDbAsync();
        }

    
    }
}
