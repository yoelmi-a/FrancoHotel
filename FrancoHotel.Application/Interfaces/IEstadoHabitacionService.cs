using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.EstadoHabitacionDtos;

namespace FrancoHotel.Application.Interfaces
{
    public interface IEstadoHabitacionService : IBaseService<SaveEstadoHabitacionDto, UpdateEstadoHabitacionDto, RemoveEstadoHabitacionDto>
    {
    }
}
