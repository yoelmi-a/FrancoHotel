using FrancoHotel.Application.Dtos.HabitacionDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public class HabitacionMapper : BaseMapper<SaveHabitacionDto, UpdateHabitacionDto, RemoveHabitacionDto, Habitacion>, IHabitacionMapper
    {
        public override List<UpdateHabitacionDto> DtoList(List<Habitacion> entities)
        {
            return entities.Select(entity => new UpdateHabitacionDto()
            {
                IdHabitacion = entity.Id,
                IdCategoria = entity.IdCategoria,
                IdEstadoHabitacion = entity.IdEstadoHabitacion,
                IdPiso = entity.IdPiso,
                Detalle = entity.Detalle!,
                Estado = entity.EstadoYFecha.Estado,
                Numero = entity.Numero!,
                Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!,
                Usuario = (int)entity.CreadorPorU!
            }).ToList();
        }

        public override UpdateHabitacionDto EntityToDto(Habitacion entity)
        {
            UpdateHabitacionDto dto = new UpdateHabitacionDto();
            dto.IdHabitacion = entity.Id;
            dto.IdEstadoHabitacion = entity.IdEstadoHabitacion;
            dto.IdCategoria = entity.IdCategoria;
            dto.IdPiso = entity.IdPiso;
            dto.Estado = entity.EstadoYFecha.Estado;
            dto.Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!;
            dto.Usuario = (int)entity.CreadorPorU!;
            dto.Numero = entity.Numero!;
            return dto;
        }

        public override Habitacion RemoveDtoToEntity(RemoveHabitacionDto dto, Habitacion entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true;
            entity.BorradoPorU = dto.Usuario;
            return entity;
        }

        public override Habitacion SaveDtoToEntity(SaveHabitacionDto dto)
        {
            Habitacion h = new Habitacion();
            h.Capacidad = dto.Capacidad;
            h.IdEstadoHabitacion = dto.IdEstadoHabitacion;
            h.IdCategoria = dto.IdCategoria;
            h.CreadorPorU = dto.Usuario;
            h.Numero = dto.Numero;
            h.IdPiso = dto.IdPiso;
            h.Detalle = dto.Detalle;
            h.EstadoYFecha.Estado = dto.Estado;
            h.EstadoYFecha.FechaCreacion = dto.Fecha;
            h.Borrado = false;
            return h;
        }

        public override Habitacion UpdateDtoToEntity(UpdateHabitacionDto dto, Habitacion h)
        {
            h.Capacidad = dto.Capacidad;
            h.IdEstadoHabitacion = dto.IdEstadoHabitacion;
            h.IdCategoria = dto.IdCategoria;
            h.UsuarioMod = dto.Usuario;
            h.Numero = dto.Numero;
            h.IdPiso = dto.IdPiso;
            h.Detalle = dto.Detalle;
            h.EstadoYFecha.Estado = dto.Estado;
            h.FechaModificacion = dto.Fecha;
            return h;
        }
    }
}
