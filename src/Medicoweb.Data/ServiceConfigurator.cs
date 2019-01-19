using Medicoweb.Data.Contracts;
using Medicoweb.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Medicoweb.Data
{
    public static class ServiceConfigurator
    {
        public static void RegisterDataModule(this IServiceCollection services)
        {
            services.AddScoped<IDataService, DataService>();
        }
    }
}
