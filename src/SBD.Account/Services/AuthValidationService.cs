
using SBD.Account.Contracts;
using SBD.Account.Models;

namespace SBD.Account.Services
{
    public class AuthValidationService : IAuthValidationService
    {
        public void ValidateRegisterViewModel(RegisterViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new RegistrationFailedException(
                    $"Email cannot be null!");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                throw new RegistrationFailedException(
                    $"Password cannot be null!");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new RegistrationFailedException(
                    $"UserName cannot be null!");
            }
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new RegistrationFailedException(
                    $"First name cannot be null!");
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new RegistrationFailedException(
                    $"Last name cannot be null!");
            }
        }

        public void ValidateSignInViewModel(SignInViewModel model)
        {
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new SignInFailedException(
                    $"Password cannot be null!");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new SignInFailedException(
                    $"UserName cannot be null!");
            }
        }
    }
}
