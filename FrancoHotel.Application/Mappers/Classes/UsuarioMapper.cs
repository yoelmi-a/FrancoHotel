using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public sealed class UsuarioMapper : BaseMapper<SaveUsuarioDtos, UpdateUsuarioDtos, RemoveUsuarioDtos, Usuario>, IUsuarioMapper
    {
        public override List<UpdateUsuarioDtos> DtoList(List<Usuario> entities)
        {
            return entities.Select(entity => new UpdateUsuarioDtos()
            {
                IdUsuario = entity.Id,
                NombreCompleto = entity.NombreCompleto!,
                Correo = entity.Correo!,
                IdRolUsuario = entity.IdRolUsuario,
                Clave = entity.Clave!,
                Estado = entity.EstadoYFecha.Estado,
                Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!,
                Usuario = (int)entity.CreadorPorU!
            }).OrderByDescending(dto => dto.IdUsuario).ToList();
        }

        public override UpdateUsuarioDtos EntityToDto(Usuario entity)
        {
            UpdateUsuarioDtos dto = new UpdateUsuarioDtos()
            {
                IdUsuario = entity.Id,
                NombreCompleto = entity.NombreCompleto!,
                Correo = entity.Correo!,
                IdRolUsuario = entity.IdRolUsuario,
                Clave = entity.Clave!,
                Estado = entity.EstadoYFecha.Estado,
                Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!,
                Usuario = (int)entity.CreadorPorU!
            };
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
            entity.Borrado = false;
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
