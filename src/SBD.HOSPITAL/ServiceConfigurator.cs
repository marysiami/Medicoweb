using Microsoft.Extensions.DependencyInjection;
using SBD.HOSPITAL.Contracts;
using SBD.HOSPITAL.Services;

namespace SBD.HOSPITAL
{
    public static class ServiceConfigurator
    {
        public static void RegisterHospitalModule(this IServiceCollection services)
        {
            services.AddScoped<IHospitalService, HospitalService>();
        }
    }
}
