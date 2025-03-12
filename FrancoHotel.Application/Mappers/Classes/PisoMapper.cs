using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public sealed class PisoMapper : BaseMapper<SavePisoDto, UpdatePisoDto, RemovePisoDto, Piso>, IPisoMapper
    {
        public override UpdatePisoDto EntityToDto(Piso entity)
        {
            UpdatePisoDto dto = new UpdatePisoDto();
            dto.Id = entity.Id;
            dto.Descripcion = entity.Descripcion!;
            dto.Estado = entity.EstadoYFecha.Estado;
            return dto;
        }

        public override Piso RemoveDtoToEntity(RemovePisoDto dto, Piso entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true;
            entity.BorradoPorU = dto.Usuario;
            return entity;
        }

        public override Piso SaveDtoToEntity(SavePisoDto dto)
        {
            Piso entity = new Piso();
            entity.Descripcion = dto.Descripcion;
            entity.EstadoYFecha.FechaCreacion = dto.Fecha;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.CreadorPorU = dto.Usuario;
            return entity;
        }

        public override Piso UpdateDtoToEntity(UpdatePisoDto dto, Piso entity)
        {
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.Descripcion = dto.Descripcion;
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            return entity;
        }
    }
}
