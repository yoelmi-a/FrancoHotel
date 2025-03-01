using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class RecepcionDependecy
    {
        public static void AddRecepcionDependency(this IServiceCollection service)
        {
            service.AddScoped<IRecepcionRepository, RecepcionRepository>();
        }
    }
}
