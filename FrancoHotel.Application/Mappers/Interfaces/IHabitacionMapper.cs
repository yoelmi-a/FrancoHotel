using FrancoHotel.Application.Dtos.HabitacionDtos;
using FrancoHotel.Domain.Entities;Queryable

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IHabitacionMapper : IBaseMapper<SaveHabitacionDto, UpdateHabitacionDto, RemoveHabitacionDto, Habitacion>
    {
    }
}
