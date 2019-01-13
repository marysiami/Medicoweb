using Microsoft.Extensions.DependencyInjection;
using SBD.PATIENT.Contracts;
using SBD.PATIENT.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.PATIENT

{
    public static class ServiceConfigurator
    {
        public static void RegisterAccountModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthValidationService, AuthValidationService>();
        }
    }
}
