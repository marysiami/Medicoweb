using Medicoweb.Drug.Contracts;
using Medicoweb.Drug.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Medicoweb.Drug
{
    public static class ServiceConfigurator
    {
        public static void RegisterDrugModule(this IServiceCollection services)
        {
            services.AddScoped<IDrugService, DrugService>();
        }
    }
}
