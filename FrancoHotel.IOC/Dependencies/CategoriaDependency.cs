using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Classes;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class CategoriaDependency
    {
        public static void AddCategoriaDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ICategoriaMapper, CategoriaMapper>();
        }
    }
}
