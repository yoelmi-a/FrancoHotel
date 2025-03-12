using FrancoHotel.Application.Dtos.RolUsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public sealed class RolUsuarioMapper : BaseMapper<SaveRolUsuarioDtos, UpdateRolUsuarioDtos, RemoveRolUsuarioDtos, RolUsuario>, IRolUsuarioMapper
    {
        public override UpdateRolUsuarioDtos EntityToDto(RolUsuario entity)
        {
            UpdateRolUsuarioDtos dto = new UpdateRolUsuarioDtos();
            dto.IdRolUsuario = entity.Id;
            dto.Descripcion = entity.Descripcion;
            dto.Estado = entity.EstadoYFecha.Estado;
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
