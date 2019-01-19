using Medicoweb.Hospital.Contracts;
using Medicoweb.Hospital.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Medicoweb.Hospital
{
    public static class ServiceConfigurator
    {
        public static void RegisterHospitalModule(this IServiceCollection services)
        {
            services.AddScoped<IHospitalService, HospitalService>();
        }
    }
}
