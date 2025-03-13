using FrancoHotel.Application.Dtos.EstadoHabitacionDtos;
using FrancoHotel.Application.Dtos.ServiciosDto;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public class EstadoHabitacionMapper : BaseMapper<SaveEstadoHabitacionDto, UpdateEstadoHabitacionDto, RemoveEstadoHabitacionDto, EstadoHabitacion>, IEstadoHabitacionMapper
    {
        public override List<UpdateEstadoHabitacionDto> DtoList(List<EstadoHabitacion> entities)
        {
            return entities.Select(e => new UpdateEstadoHabitacionDto()
            {
                Descripcion = e.Descripcion!,
                Estado = (bool)e.EstadoYFecha.Estado!,
                Fecha = (DateTime)e.EstadoYFecha.FechaCreacion!,
                IdEstadoHabitacion = e.Id,
                Usuario = (int)e.CreadorPorU!,

            }).ToList();
        }

        public override UpdateEstadoHabitacionDto EntityToDto(EstadoHabitacion entity)
        {
            UpdateEstadoHabitacionDto dto = new UpdateEstadoHabitacionDto();
            dto.IdEstadoHabitacion = entity.Id;
            dto.Descripcion = entity.Descripcion!;
            dto.Usuario = (int)entity.CreadorPorU!;
            dto.Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!;
            dto.Estado = (bool)entity.EstadoYFecha.Estado!;
            return dto;
        }

        public override EstadoHabitacion RemoveDtoToEntity(RemoveEstadoHabitacionDto dto, EstadoHabitacion entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true;
            entity.BorradoPorU = dto.Usuario;
            return entity;
        }

        public override EstadoHabitacion SaveDtoToEntity(SaveEstadoHabitacionDto dto)
        {
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = dto.Descripcion;
            estado.EstadoYFecha.FechaCreacion = dto.Fecha;
            estado.EstadoYFecha.Estado = dto.Estado;
            estado.CreadorPorU = dto.Usuario;
            estado.Borrado = false;
            return estado;
        }

        public override EstadoHabitacion UpdateDtoToEntity(UpdateEstadoHabitacionDto dto, EstadoHabitacion entity)
        {
            entity.Descripcion = dto.Descripcion;
            entity.FechaModificacion = dto.Fecha;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.UsuarioMod = dto.Usuario;
            return entity;
        }
    }
}
