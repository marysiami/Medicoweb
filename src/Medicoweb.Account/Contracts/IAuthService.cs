using System.Threading.Tasks;
using Medicoweb.Account.Models;

namespace Medicoweb.Account.Contracts
{
    public interface IAuthService
    {
        Task<string> Register(RegisterViewModel model);
        Task<string> Signin(SignInViewModel model);
    }
}