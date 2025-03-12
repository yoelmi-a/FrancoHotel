﻿using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Dtos.TarifasDto;
using FrancoHotel.Application.Dtos.TarifasDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IPisoMapper : IBaseMapper<SavePisoDto, UpdatePisoDto, RemovePisoDto, Piso>
    {
    }
}
