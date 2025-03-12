using FrancoHotel.Application.Dtos.EstadoHabitacionDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public class EstadoHabitacionMapper : BaseMapper<SaveEstadoHabitacionDto, UpdateEstadoHabitacionDto, RemoveEstadoHabitacionDto, EstadoHabitacion>, IEstadoHabitacionMapper
    {
        public override List<UpdateEstadoHabitacionDto> DtoList(List<EstadoHabitacion> entities)
        {
            throw new NotImplementedException();
        }

        public override UpdateEstadoHabitacionDto EntityToDto(EstadoHabitacion entity)
        {
            throw new NotImplementedException();
        }

        public override EstadoHabitacion RemoveDtoToEntity(RemoveEstadoHabitacionDto dto, EstadoHabitacion entity)
        {
            throw new NotImplementedException();
        }

        public override EstadoHabitacion SaveDtoToEntity(SaveEstadoHabitacionDto dto)
        {
            throw new NotImplementedException();
        }

        public override EstadoHabitacion UpdateDtoToEntity(UpdateEstadoHabitacionDto dto, EstadoHabitacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
