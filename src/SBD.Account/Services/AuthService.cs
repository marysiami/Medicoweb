﻿

using SBD.Account.Contracts;

namespace SBD.Account.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Patient> _userManager;
        private readonly SignInManager<OmdleUser> _signInManager;
        private readonly IAuthValidationService _authValidationService;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<OmdleUser> userManager,
            SignInManager<OmdleUser> signInManager,
            IAuthValidationService authValidationService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authValidationService = authValidationService;
            _configuration = configuration;
        }

        public async Task<string> Register(RegisterViewModel model)
        {
            _authValidationService.ValidateRegisterViewModel(model);

            var newUser = new OmdleUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
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

        public async Task<string> SignIn(SignInViewModel model)
        {
            _authValidationService.ValidateSignInViewModel(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (!result.Succeeded)
            {
                throw new SignInFailedException(
                    $"An error occured while signing in user: {model.UserName}");
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            return GetToken(user);
        }

        private string GetToken(OmdleUser user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
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