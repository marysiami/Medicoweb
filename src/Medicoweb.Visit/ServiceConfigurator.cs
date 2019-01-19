using Medicoweb.Visit.Contracts;
using Medicoweb.Visit.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Medicoweb.Visit
{
    public static class ServiceConfigurator
    {
        public static void RegisterVisitModule(this IServiceCollection services)
        {
            services.AddScoped<IVisitService, VisitService>();
            services.AddScoped<IPrescriptionService, PresriptionService>();
        }
    }
}