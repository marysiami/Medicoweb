using SBD.COMMON.Exceptions;
using SBD.DATA.Contracts;
using SBD.DATA.Models;
using SBD.PATIENT.Contracts;
using SBD.PATIENT.Models;
using System.Threading.Tasks;

namespace SBD.PATIENT.Services
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

            if (string.IsNullOrEmpty(model.Pesel))
            {
                throw new SignInFailedException(
                    $"Pesel cannot be null or empty!");
            }

            return Task.CompletedTask;
        }
    }


}
    
