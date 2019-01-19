using Medicoweb.Account.Contracts;
using Medicoweb.Account.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Medicoweb.Account
{
    public static class ServiceConfigurator
    {
        public static void RegisterAccountModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthValidationService, AuthValidationService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}