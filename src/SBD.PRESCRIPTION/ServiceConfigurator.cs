using Microsoft.Extensions.DependencyInjection;
using SBD.PRESCRIPTION.Contracts;
using SBD.PRESCRIPTION.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBD.PRESCRIPTION
{
    public static class ServiceConfigurator
    {
        public static void PrescriptionModule(this IServiceCollection services)
        {
            services.AddScoped<IPrescriptionService, PrescriptionService>();
        }
    }
}
