using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class ServiciosDependecy
    {
        public static void AddServiciosDependecy(this IServiceCollection services)
        {
            services.AddScoped<IServiciosRepository, ServiciosRepository>();
        }
    }
}
