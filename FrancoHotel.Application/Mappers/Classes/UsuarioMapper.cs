using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public sealed class UsuarioMapper : BaseMapper<SaveUsuarioDtos, UpdateUsuarioDtos, RemoveUsuarioDtos, Usuario>, IUsuarioMapper
    {
        public override UpdateUsuarioDtos EntityToDto(Usuario entity)
        {
            UpdateUsuarioDtos dto = new UpdateUsuarioDtos();
            dto.IdUsuario = entity.Id;
            dto.NombreCompleto = entity.NombreCompleto;
            dto.Correo = entity.Correo;
            dto.IdRolUsuario = entity.IdRolUsuario;
            dto.Clave = entity.Clave;
            dto.Estado = entity.EstadoYFecha.Estado;
            return dto;
        }

        public override Usuario RemoveDtoToEntity(RemoveUsuarioDtos dto, Usuario entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = dto.Borrado;
            return entity;
        }

        public override Usuario SaveDtoToEntity(SaveUsuarioDtos dto)
        {
            Usuario entity = new Usuario();
            entity.NombreCompleto = dto.NombreCompleto;
            entity.Correo = dto.Correo;
            entity.IdRolUsuario = dto.IdRolUsuario;
            entity.Clave = dto.Clave;
            entity.EstadoYFecha.FechaCreacion = dto.Fecha;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.CreadorPorU = dto.Usuario;
            return entity;
        }

        public override Usuario UpdateDtoToEntity(UpdateUsuarioDtos dto, Usuario entity)
        {
            entity.NombreCompleto = dto.NombreCompleto;
            entity.Correo = dto.Correo;
            entity.IdRolUsuario = dto.IdRolUsuario;
            entity.Clave = dto.Clave;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            return entity;
        }
    }
}
