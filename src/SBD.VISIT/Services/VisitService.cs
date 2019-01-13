using Microsoft.EntityFrameworkCore;
using SBD.DATA.Contracts;
using SBD.DATA.Models;
using SBD.VISIT.Contracts;
using SBD.VISIT.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBD.VISIT.Services
{
    public class VisitService : IVisitService
    {
        public readonly IDataService _dataService;
        public VisitService (IDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task <Visit> CreateVisit (VisitViewModel model)
        {
            var newVisit = new Visit
            {
                DoctorId = model.DoctorId,
                PatientId = model.PatientId,
                Date = model.VisitDate
            };
            await _dataService.GetSet<Visit>().AddAsync(newVisit);
            await _dataService.SaveDbAsync();
            return newVisit;

        }
        public async Task RemoveVisit(Guid visitId)
        {
            var set = _dataService.GetSet<Visit>();
            var visitToRemove = await set.FirstOrDefaultAsync(x => x.Id == visitId);
            set.Remove(visitToRemove);
            await _dataService.SaveDbAsync();

        }

        public async Task <Visit> EditVisit (Guid visitId, VisitViewModel model)
        {
            var set =  _dataService.GetSet<Visit>();
            var editedVisit = await set.FirstOrDefaultAsync(x => x.Id == visitId);
            editedVisit.Date = model.VisitDate;


            set.Update(editedVisit);
            await _dataService.SaveDbAsync();
            return editedVisit;
        }
      /* public async Task<Visit> GetDoctorVisits (Guid doctorId)
        {
            var set = _dataService.GetSet<Visit>();
            var doctor = await set.FirstOrDefaultAsync(x => x.Id == doctorId);
            var doctorVisits = await set.ToListAsync(x => x.Id == doctorId);

        }
        public async Task<Visit> GetPatientVisits(Guid patientId)
        {
            var set = _dataService.GetSet<Visit>();

        }
        */

    }
}
