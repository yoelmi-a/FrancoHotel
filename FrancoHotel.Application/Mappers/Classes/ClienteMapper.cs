using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public sealed class ClienteMapper : BaseMapper<SaveClienteDtos, UpdateClienteDtos, RemoveClienteDtos, Cliente>, IClienteMapper
    {
        public override List<UpdateClienteDtos> DtoList(List<Cliente> entities)
        {
            return entities.Select(entity => new UpdateClienteDtos()
            {
                IdCliente = entity.Id,
                TipoDocumento = entity.TipoDocumento,
                Documento = entity.Documento,
                NombreCompleto = entity.NombreCompleto,
                Correo = entity.Correo,
                Estado = entity.EstadoYFecha.Estado,
                Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!,
                Usuario = (int)entity.CreadorPorU!
            }).ToList();
        }

        public override UpdateClienteDtos EntityToDto(Cliente entity)
        {
            UpdateClienteDtos dto = new UpdateClienteDtos();
            dto.IdCliente = entity.Id;
            dto.TipoDocumento = entity.TipoDocumento;
            dto.Documento = entity.Documento;
            dto.NombreCompleto = entity.NombreCompleto;
            dto.Correo = entity.Correo;
            dto.Estado = entity.EstadoYFecha.Estado;
            return dto;
        }

        public override Cliente RemoveDtoToEntity(RemoveClienteDtos dto, Cliente entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = dto.Borrado;
            return entity;
        }

        public override Cliente SaveDtoToEntity(SaveClienteDtos dto)
        {
            Cliente entity = new Cliente();
            entity.TipoDocumento = dto.TipoDocumento;
            entity.Documento = dto.Documento;
            entity.NombreCompleto = dto.NombreCompleto;
            entity.Correo = dto.Correo;
            entity.EstadoYFecha.FechaCreacion = dto.Fecha;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.CreadorPorU = dto.Usuario;
            return entity;
        }

        public override Cliente UpdateDtoToEntity(UpdateClienteDtos dto, Cliente entity)
        {
            entity.TipoDocumento = dto.TipoDocumento;
            entity.Documento = dto.Documento;
            entity.NombreCompleto = dto.NombreCompleto;
            entity.Correo = dto.Correo;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            return entity;
        }
    }
}
