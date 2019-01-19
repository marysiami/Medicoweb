using System.Threading.Tasks;
using Medicoweb.Data.Models.Account;

namespace Medicoweb.Account.Contracts
{
    public interface IUserService
    {
        Task<MedicowebUser> GetUserByIdAsync(string id);
        Task<MedicowebUser> GetUserByNameAsync(string userName);
    }
}