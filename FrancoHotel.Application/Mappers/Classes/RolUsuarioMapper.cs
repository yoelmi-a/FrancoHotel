using FrancoHotel.Application.Dtos.RolUsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public sealed class RolUsuarioMapper : BaseMapper<SaveRolUsuarioDtos, UpdateRolUsuarioDtos, RemoveRolUsuarioDtos, RolUsuario>, IRolUsuarioMapper
    {
        public override List<UpdateRolUsuarioDtos> DtoList(List<RolUsuario> entities)
        {
            return entities.Select(entity => new UpdateRolUsuarioDtos()
            {
                IdRolUsuario = entity.Id,
                Descripcion = entity.Descripcion,
                Estado = entity.EstadoYFecha.Estado,
                Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!,
                Usuario = (int)entity.CreadorPorU!
            }).OrderByDescending(dto => dto.IdRolUsuario).ToList();
        }

        public override UpdateRolUsuarioDtos EntityToDto(RolUsuario entity)
        {
            UpdateRolUsuarioDtos dto = new UpdateRolUsuarioDtos()
            {
                IdRolUsuario = entity.Id,
                Descripcion = entity.Descripcion,
                Estado = entity.EstadoYFecha.Estado,
                Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!,
                Usuario = (int)entity.CreadorPorU!
            };
            return dto;
        }

        public override RolUsuario RemoveDtoToEntity(RemoveRolUsuarioDtos dto, RolUsuario entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = dto.Borrado;
            return entity;
        }

        public override RolUsuario SaveDtoToEntity(SaveRolUsuarioDtos dto)
        {
            RolUsuario entity = new RolUsuario();
            entity.Descripcion = dto.Descripcion;
            entity.EstadoYFecha.FechaCreacion = dto.Fecha;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.CreadorPorU = dto.Usuario;
            entity.Borrado = false;
            return entity;
        }

        public override RolUsuario UpdateDtoToEntity(UpdateRolUsuarioDtos dto, RolUsuario entity)
        {
            entity.Descripcion = dto.Descripcion;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            return entity;
        }
    }
}
