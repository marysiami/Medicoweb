using Microsoft.Extensions.DependencyInjection;
using SBD.DATA.Contracts;
using SBD.DATA.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.DATA
{
    public static class ServiceConfigurator
    {
        public static void RegisterDataModule(this IServiceCollection services)
        {
            services.AddScoped<IDataService, DataService>();
        }
    }
}
