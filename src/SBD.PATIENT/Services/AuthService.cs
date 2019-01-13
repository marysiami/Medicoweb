using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SBD.COMMON.Exceptions;
using SBD.DATA.Models;
using SBD.PATIENT.Contracts;
using SBD.PATIENT.Models;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SBD.PATIENT.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthValidationService _authValidationService;
        private readonly UserManager<Patient> _userManager;
        private readonly SignInManager<Patient> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthService( UserManager<Patient> userManager,
                            SignInManager<Patient> signInManager,
                            IAuthValidationService authValidationService,
                            IConfiguration configuration)
        {
            _authValidationService = authValidationService;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;

        }
        public async Task <string> Register (RegisterViewModel model)
        {
             _authValidationService.ValidateRegisterViewModel(model);

            var newUser = new Patient
            {
                Name = model.Name,
                Surname = model.Surname,
                Pesel = model.Pesel
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                throw new RegistrationFailedException(
                   $"An error occured while registering user: {result.Errors.Select(e => e.Description).Join(", ")}");
            }
            await _signInManager.SignInAsync(newUser, false);
            return GetToken(newUser);
        }

        public async Task<string>Signin(SignInViewModel model)
        {
            await _authValidationService.ValidateSignInViewModel(model);

            var result = await _signInManager.PasswordSignInAsync(model.Pesel, model.Password, false, false);

            if (!result.Succeeded)
            {
                throw new SignInFailedException(
                    $"An error occured while signing in user: {model.Pesel}");
            }

            var user = await _userManager.FindByNameAsync(model.Pesel);
            return GetToken(user);
        }
        private string GetToken(Patient user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Pesel),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString(CultureInfo.InvariantCulture))
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Tokens:Key")));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddSeconds(_configuration.GetValue<int>("Tokens:Lifetime"))
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }


}

