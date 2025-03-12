using FrancoHotel.Application.Dtos.EstadoHabitacionDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IEstadoHabitacionMapper : IBaseMapper<SaveEstadoHabitacionDto, UpdateEstadoHabitacionDto, RemoveEstadoHabitacionDto, EstadoHabitacion>
    {
    }
}
