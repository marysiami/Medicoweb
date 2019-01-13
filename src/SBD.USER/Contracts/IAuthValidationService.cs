using SBD.USER.Models;
using System.Threading.Tasks;

namespace SBD.USER.Contracts
{
    public interface IAuthValidationService
    {
        void ValidateRegisterViewModel(RegisterViewModel model);
        Task ValidateSignInViewModel(SignInViewModel model);
    }
}
