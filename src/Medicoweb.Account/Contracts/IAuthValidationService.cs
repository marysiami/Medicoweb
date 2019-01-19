using System.Threading.Tasks;
using Medicoweb.Account.Models;

namespace Medicoweb.Account.Contracts
{
    public interface IAuthValidationService
    {
        void ValidateRegisterViewModel(RegisterViewModel model);
        Task ValidateSignInViewModel(SignInViewModel model);
    }
}
