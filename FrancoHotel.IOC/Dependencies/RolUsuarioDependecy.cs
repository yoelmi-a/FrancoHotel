﻿using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FrancoHotel.IOC.Dependencies
{
    public static class RolUsuarioDependecy
    {
        public static void AddRolUsuarioDependecy(this IServiceCollection services)
        {
            services.AddScoped<IRolUsuarioRepository, RolUsuarioRepository>();
        }
    }
}
