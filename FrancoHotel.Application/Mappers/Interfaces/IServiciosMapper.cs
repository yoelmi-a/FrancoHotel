using FrancoHotel.Application.Dtos.ServiciosDto;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IServiciosMapper : IBaseMapper<SaveServiciosDto, UpdateServiciosDto, RemoveServiciosDto, Servicios>
    {
    }
}
