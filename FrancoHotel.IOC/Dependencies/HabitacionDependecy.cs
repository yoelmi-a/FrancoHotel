using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class HabitacionDependecy
    {
        public static void AddHabitacionDependecy(this IServiceCollection services)
        {
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();
        }
    }
}
