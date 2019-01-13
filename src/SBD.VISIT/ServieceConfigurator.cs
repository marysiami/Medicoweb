using Microsoft.Extensions.DependencyInjection;
using SBD.VISIT.Contracts;
using SBD.VISIT.Services;

namespace SBD.VISIT
{
    public static class ServieceConfigurator
    {
        public static void VisitModule(this IServiceCollection services)
        {
            services.AddScoped<IVisitService, VisitService>();

        }
    }
}
