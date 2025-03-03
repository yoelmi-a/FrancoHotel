using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class UsuarioDependecy
    {
        public static void AddUsuarioDependecy(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
