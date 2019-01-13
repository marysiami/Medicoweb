using SBD.Account.Models;
using System.Threading.Tasks;

namespace SBD.Account.Contracts
{
    public interface IAuthService
    {
        Task<string> Register(RegisterViewModel model);
        Task<string> SignIn(SignInViewModel model);
    }
}
