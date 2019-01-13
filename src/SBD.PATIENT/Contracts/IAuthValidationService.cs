using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SBD.PATIENT.Models;

namespace SBD.PATIENT.Contracts
{
    public interface IAuthValidationService
    {
        void ValidateRegisterViewModel(RegisterViewModel model);
        Task ValidateSignInViewModel(SignInViewModel model);
    }
}
