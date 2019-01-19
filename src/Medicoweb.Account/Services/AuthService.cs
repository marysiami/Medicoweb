using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Medicoweb.Account.Contracts;
using Medicoweb.Account.Models;
using Medicoweb.Common.Exceptions;
using Medicoweb.Data.Contracts;
using Medicoweb.Data.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Medicoweb.Account.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthValidationService _authValidationService;
        private readonly IConfiguration _configuration;
        private readonly IDataService _dataService;
        private readonly SignInManager<MedicowebUser> _signInManager;
        private readonly UserManager<MedicowebUser> _userManager;

        public AuthService(UserManager<MedicowebUser> userManager,
            SignInManager<MedicowebUser> signInManager,
            IAuthValidationService authValidationService,
            IConfiguration configuration,
            IDataService dataService)
        {
            _authValidationService = authValidationService;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _dataService = dataService;
        }

        public async Task<string> Register(RegisterViewModel model)
        {
            _authValidationService.ValidateRegisterViewModel(model);

            var newUser = new MedicowebUser
            {
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname,
                Pesel = model.Pesel
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
                throw new RegistrationFailedException(
                    $"An error occured while registering user: {result.Errors.Select(e => e.Description).Join(", ")}");
            await _userManager.AddToRoleAsync(newUser, "Patient");
            await _signInManager.SignInAsync(newUser, false);

            var token = await GetToken(newUser);

            return token;
        }

        public async Task<string> Signin(SignInViewModel model)
        {
            await _authValidationService.ValidateSignInViewModel(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (!result.Succeeded)
                throw new SignInFailedException(
                    $"An error occured while signing in user: {model.UserName}");

            var user = await _userManager.FindByNameAsync(model.UserName);

            var token = await GetToken(user);

            return token;
        }

        private async Task<string> GetToken(MedicowebUser user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString(CultureInfo.InvariantCulture))
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim("role", role));
            }

            var signingKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Tokens:Key")));
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