using Microsoft.Extensions.DependencyInjection;
using SBD.VISIT.Contracts;
using SBD.VISIT.Services;
using System;

namespace SBD.VISIT
{
    public static class ServiceConfigurator
    {
        public static void RegisterVisitModule(this IServiceCollection services)
        {
            services.AddScoped<IVisitService, VisitService>();           
        }
    }
}

