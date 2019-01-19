using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Medicoweb.Data.Contracts
{
    public interface IDataService
    {
        DbSet<T> GetSet<T>() where T : class;
        Task SaveDbAsync();
    }
}