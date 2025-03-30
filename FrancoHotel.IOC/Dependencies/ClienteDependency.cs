using FrancoHotel.Application.Mappers.Classes;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class ClienteDependency
    {
        public static void AddClienteDependency(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteMapper, ClienteMapper>();
        }
    }
}
