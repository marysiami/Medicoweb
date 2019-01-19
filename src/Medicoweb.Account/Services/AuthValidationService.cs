using System.Threading.Tasks;
using Medicoweb.Account.Contracts;
using Medicoweb.Account.Models;
using Medicoweb.Common.Exceptions;
using Medicoweb.Data.Contracts;

namespace Medicoweb.Account.Services
{
    public class AuthValidationService : IAuthValidationService
    {
        private readonly IDataService _dataService;

        public AuthValidationService (IDataService dataService)
        {
            _dataService = dataService;
        }
        public void ValidateRegisterViewModel (RegisterViewModel model)
        {
           
            if (string.IsNullOrEmpty(model.Pesel))
            {
                throw new RegistrationFailedException(
                    $"Pesel cannot be null or empty!");
            }
            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new RegistrationFailedException(
                    $"UserName cannot be null or empty!");
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new RegistrationFailedException(
                       $"Name cannot be null or empty!");

            }

            if (string.IsNullOrEmpty(model.Surname))
            {
                throw new RegistrationFailedException(
                    $"Surname cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                throw new RegistrationFailedException(
                    $"Password cannot be null or empty!");
            }
        }

        public Task ValidateSignInViewModel(SignInViewModel model)
        {
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new SignInFailedException(
                    $"Password cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new SignInFailedException(
                    $"UserName cannot be null or empty!");
            }

            return Task.CompletedTask;
        }
    }


}
    
