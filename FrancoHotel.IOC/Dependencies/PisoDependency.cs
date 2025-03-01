using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class PisoDependency
    {
        public static void AddPisoDependency(this IServiceCollection service)
        {
            service.AddScoped<IPisoRepository, PisoRepository>();
            service.AddTransient<IPisoService, PisoService>();
        }
    }
}
