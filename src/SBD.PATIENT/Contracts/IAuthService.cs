using SBD.PATIENT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBD.PATIENT.Contracts
{
    public interface IAuthService
    {
        Task<string> Register(RegisterViewModel model);
        Task<string> Signin(SignInViewModel model);
    }
}
