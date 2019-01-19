using System.Threading.Tasks;
using Medicoweb.Account.Contracts;
using Medicoweb.Data.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace Medicoweb.Account.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<SBDUser> _userManager;

        public UserService(
            UserManager<SBDUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<SBDUser> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<SBDUser> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

      
    }
}
