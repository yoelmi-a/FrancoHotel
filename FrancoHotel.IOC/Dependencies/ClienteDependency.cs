using FrancoHotel.Persistence.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class ClienteDependency
    {
        public static void AddClienteDependency(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
