﻿using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Classes;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class TarifasDependecy
    {
        public static void AddTarifasDependecy(this IServiceCollection services)
        {
            services.AddScoped<ITarifasRepository, TarifasRepository>();
            services.AddTransient<ITarifasService, TarifasService>();
            services.AddTransient<ITarifasMapper, TarifasMapper>();
        }
    }
}
