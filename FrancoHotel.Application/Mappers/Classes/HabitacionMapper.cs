using FrancoHotel.Application.Dtos.HabitacionDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public class HabitacionMapper : BaseMapper<SaveHabitacionDto, UpdateHabitacionDto, RemoveHabitacionDto, Habitacion>, IHabitacionMapper
    {
        public override UpdateHabitacionDto EntityToDto(Habitacion entity)
        {
            throw new NotImplementedException();
        }

        public override Habitacion RemoveDtoToEntity(RemoveHabitacionDto dto, Habitacion entity)
        {
            throw new NotImplementedException();
        }

        public override Habitacion SaveDtoToEntity(SaveHabitacionDto dto)
        {
            throw new NotImplementedException();
        }

        public override Habitacion UpdateDtoToEntity(UpdateHabitacionDto dto, Habitacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
