﻿using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IServiciosRepository : IBaseRepository<Servicios, int>
    {
    }
}
