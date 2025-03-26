using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IRecepcionMapper : IBaseMapper<SaveRecepcionDto, UpdateRecepcionDto, RemoveRecepcionDto, Recepcion>
    {
    }
}
