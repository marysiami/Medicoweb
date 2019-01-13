using Microsoft.AspNetCore.Identity;
using SBD.DATA.Models.Account;
using SBD.USER.Contracts;
using System.Threading.Tasks;

namespace SBD.USER.Services
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
