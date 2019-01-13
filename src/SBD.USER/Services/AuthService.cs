using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using SBD.COMMON.Exceptions;
using SBD.DATA.Models.Account;
using SBD.USER.Contracts;
using SBD.USER.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SBD.USER.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthValidationService _authValidationService;
        private readonly UserManager<SBDUser> _userManager;
        private readonly SignInManager<SBDUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthService( UserManager<SBDUser> userManager,
                            SignInManager<SBDUser> signInManager,
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

            var newUser = new SBDUser
            {
                UserName = model.UserName,
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

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (!result.Succeeded)
            {
                throw new SignInFailedException(
                    $"An error occured while signing in user: {model.UserName}");
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            return GetToken(user);
        }
        private string GetToken(SBDUser user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, utcNow.ToString(CultureInfo.InvariantCulture))
            };

            var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Tokens:Key")));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddSeconds(_configuration.GetValue<int>("Tokens:Lifetime"))
            );

            return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }


}

