using Microsoft.EntityFrameworkCore;
using SBD.DATA.Contracts;
using System.Threading.Tasks;

namespace SBD.DATA.Services
{

    public class DataService : IDataService
    {
        private readonly SBDDbContext _dbContext;

        public DataService(SBDDbContext dbContext)
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

