using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Classes;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class EstadoHabitacionDependecy
    {
        public static void AddEstadoHabitacionDependecy(this IServiceCollection services)
        {
            services.AddScoped<IEstadoHabitacionRepository, EstadoHabitacionRepository>();
            services.AddTransient<IEstadoHabitacionService, EstadoHabitacionService>();
            services.AddTransient<IEstadoHabitacionMapper, EstadoHabitacionMapper>();
        }
    }
}
