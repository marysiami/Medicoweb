using SBD.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBD.DRUG.Contracts
{
    public interface IDrugService
    {
        Task<Drug> CreateDrug(string name, string company, bool isPrescriptionNeeded);
        Task DeleteDrug(string id);
        Task<List<Drug>> GetDrugs();
        Task<Drug> GetDrug(string id);
        Task<List<Drug>> GetDrugsFromRec(string id);
        Task<List<Drug>> GetDrugsFromPharm(string id);
    }
}
