using SBD.Account.Models;

namespace SBD.Account.Contracts
{
    public interface IAuthValidationService
    {
        void ValidateRegisterViewModel(RegisterViewModel model);
        void ValidateSignInViewModel(SignInViewModel model);
    }
}
