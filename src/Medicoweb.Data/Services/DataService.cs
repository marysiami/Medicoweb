using System.Threading.Tasks;
using Medicoweb.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Medicoweb.Data.Services
{

    public class DataService : IDataService
    {
        private readonly MedicowebDbContext _dbContext;

        public DataService(MedicowebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public async Task SaveDbAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

