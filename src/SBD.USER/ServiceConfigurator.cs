using Microsoft.Extensions.DependencyInjection;
using SBD.USER.Contracts;
using SBD.USER.Services;

namespace SBD.USER
{
    public static class ServiceConfigurator
{
    public static void RegisterAccountModule(this IServiceCollection services)
    { 
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthValidationService, AuthValidationService>();
        services.AddScoped<IUserService,UserService>();
    }
}
}
