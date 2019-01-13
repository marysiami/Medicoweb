using SBD.USER.Models;
using System.Threading.Tasks;

namespace SBD.USER.Contracts
{
    public interface IAuthService
    {
        Task<string> Register(RegisterViewModel model);
        Task<string> Signin(SignInViewModel model);
    }
}
