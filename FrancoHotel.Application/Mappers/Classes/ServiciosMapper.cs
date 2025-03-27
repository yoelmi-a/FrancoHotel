using FrancoHotel.Application.Dtos.ServiciosDto;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public class ServiciosMapper : BaseMapper<SaveServiciosDto, UpdateServiciosDto, RemoveServiciosDto, Servicios>, IServiciosMapper
    {
        public override List<UpdateServiciosDto> DtoList(List<Servicios> entities)
        {
            return entities.Select(e => new UpdateServiciosDto()
            {
                Descripcion = e.Descripcion!,
                IdServicio = e.Id,
                Usuario = (int)e.CreadorPorU!,
                Fecha = (DateTime)e.FechaCreacion!,
                Nombre = e.Nombre!,
                Precio = e.Precio!,
            }).ToList();
        }

        public override UpdateServiciosDto EntityToDto(Servicios entity)
        {
            UpdateServiciosDto dto = new UpdateServiciosDto();
            dto.IdServicio = entity.Id;
            dto.Descripcion = entity.Descripcion!;
            dto.Usuario = (int)entity.CreadorPorU!;
            dto.Fecha = (DateTime)entity.FechaCreacion!;
            dto.Nombre = entity.Nombre!;
            dto.Precio = entity.Precio;
            return dto;
        }

        public override Servicios RemoveDtoToEntity(RemoveServiciosDto dto, Servicios entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true;
            entity.BorradoPorU = dto.Usuario;
            return entity;
        }

        public override Servicios SaveDtoToEntity(SaveServiciosDto dto)
        {
            Servicios entity = new Servicios();
            entity.Descripcion = dto.Descripcion;
            entity.FechaCreacion = dto.Fecha;
            entity.CreadorPorU = dto.Usuario;
            entity.Nombre = dto.Nombre;
            entity.Precio = dto.Precio;
            entity.Borrado = false;
            return entity;
        }

        public override Servicios UpdateDtoToEntity(UpdateServiciosDto dto, Servicios entity)
        {
            entity.Descripcion = dto.Descripcion;
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Nombre = dto.Nombre;
            entity.Precio = dto.Precio;
            return entity;
        }
    }
}
