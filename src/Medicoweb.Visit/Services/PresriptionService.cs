using Medicoweb.Data.Contracts;
using Medicoweb.Data.Models;
using Medicoweb.Data.Models.Visit;
using Medicoweb.Visit.Contracts;
using Medicoweb.Visit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medicoweb.Visit.Services
{
    public class PresriptionService : IPrescriptionService
    {
        private readonly IDataService _dataService;
  

        public PresriptionService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Prescription> CreatePrescriptionAsync(Data.Models.Visit.Visit visit)
        {
            var model = new Prescription
            {
                Visit = visit,
                VisitId = visit.Id
            };
            await _dataService.GetSet<Prescription>().AddAsync(model);
            await _dataService.SaveDbAsync();

            return model;
        }

        public Task<PrescriptionListing> GetPatientPrescriptions(string patientId, int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Prescription> GetPrescriptionById(string id)
        {
            var model = _dataService.GetSet<Prescription>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            return model;
        }
    }
}
