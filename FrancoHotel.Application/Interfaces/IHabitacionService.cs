using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.HabitacionDtos;

namespace FrancoHotel.Application.Interfaces
{
    public interface IHabitacionService : IBaseService<SaveHabitacionDto, UpdateHabitacionDto, RemoveHabitacionDto>
    {
    }
}
