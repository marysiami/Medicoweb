using System.Threading.Tasks;
using Medicoweb.Account.Contracts;
using Medicoweb.Data.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace Medicoweb.Account.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<MedicowebUser> _userManager;

        public UserService(
            UserManager<MedicowebUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<MedicowebUser> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<MedicowebUser> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }
    }
}