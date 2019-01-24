using Medicoweb.Pharmacy.Contracts;
using Medicoweb.Pharmacy.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Medicoweb.Pharmacy
{
    public static class ServiceConfigurator
    {
        public static void RegisterPharmacyModule(this IServiceCollection services)
        {
            services.AddScoped<IPharmacyService, PharmacyService>();
        }
    }
}
