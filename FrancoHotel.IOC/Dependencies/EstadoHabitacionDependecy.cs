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
        }
    }
}
