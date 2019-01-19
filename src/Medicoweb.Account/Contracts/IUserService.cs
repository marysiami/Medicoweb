using System.Threading.Tasks;
using Medicoweb.Data.Models.Account;

namespace Medicoweb.Account.Contracts
{
    public interface IUserService
    {
        Task<SBDUser> GetUserByIdAsync(string id);
        Task<SBDUser> GetUserByNameAsync(string userName);
    }
}
