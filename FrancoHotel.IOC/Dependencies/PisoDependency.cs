using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Classes;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class PisoDependency
    {
        public static void AddPisoDependency(this IServiceCollection services)
        {
            services.AddScoped<IPisoRepository, PisoRepository>();
            services.AddTransient<IPisoService, PisoService>();
            services.AddTransient<IPisoMapper, PisoMapper>();
        }
    }
}
