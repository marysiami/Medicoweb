using Microsoft.Extensions.DependencyInjection;
using SBD.DRUG.Contracts;
using SBD.DRUG.Services;

namespace SBD.DRUG
{
    public static class ServiceConfigurator
    {
        public static void DrugModule(this IServiceCollection services)
        {
            services.AddScoped<IDrugService, DrugService>();
        }
    }
}
