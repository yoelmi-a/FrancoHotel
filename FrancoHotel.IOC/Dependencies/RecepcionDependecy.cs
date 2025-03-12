using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Classes;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class RecepcionDependecy
    {
        public static void AddRecepcionDependency(this IServiceCollection services)
        {
            services.AddScoped<IRecepcionRepository, RecepcionRepository>();
            services.AddTransient<IRecepcionService, RecepcionService>();
            services.AddTransient<IRecepcionMapper, RecepcionMapper>();
        }
    }
}
