using SBD.DATA.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBD.USER.Contracts
{
    public interface IUserService
    {
        Task<SBDUser> GetUserByIdAsync(string id);
        Task<SBDUser> GetUserByNameAsync(string userName);
    }
}
