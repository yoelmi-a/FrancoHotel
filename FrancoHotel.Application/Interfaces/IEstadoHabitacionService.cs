using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.EstadoHabitacionDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Interfaces
{
    public interface IEstadoHabitacionService : IBaseService<SaveEstadoHabitacionDto, UpdateEstadoHabitacionDto, RemoveEstadoHabitacionDto>
    {
    }
}
