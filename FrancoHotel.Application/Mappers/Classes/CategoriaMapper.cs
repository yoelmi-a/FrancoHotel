using FrancoHotel.Application.Dtos.CategoriaDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Classes
{
    public sealed class CategoriaMapper : BaseMapper<SaveCategoriaDto, UpdateCategoriaDto, RemoveCategoriaDto, Categoria>, ICategoriaMapper
    {
        public override List<UpdateCategoriaDto> DtoList(List<Categoria> entities)
        {
            return entities.Select(e => new UpdateCategoriaDto()
            {
                Id = e.Id,
                Descripcion = e.Descripcion!,
                Estado = e.EstadoYFecha.Estado,
                Usuario = (int)e.CreadorPorU!,
                Fecha = (DateTime)e.EstadoYFecha.FechaCreacion!
            }).OrderByDescending(dto => dto.Id).ToList();
        }

        public override UpdateCategoriaDto EntityToDto(Categoria entity)
        {
            UpdateCategoriaDto dto = new UpdateCategoriaDto();
            dto.Id = entity.Id;
            dto.Descripcion = entity.Descripcion!;
            dto.Estado = entity.EstadoYFecha.Estado;
            dto.Usuario = (int)entity.CreadorPorU!;
            dto.Fecha = (DateTime)entity.EstadoYFecha.FechaCreacion!;
            return dto;
        }

        public override Categoria RemoveDtoToEntity(RemoveCategoriaDto dto, Categoria entity)
        {
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            entity.Borrado = true;
            entity.BorradoPorU = dto.Usuario;
            return entity;
        }

        public override Categoria SaveDtoToEntity(SaveCategoriaDto dto)
        {
            Categoria entity = new Categoria();
            entity.Descripcion = dto.Descripcion;
            entity.EstadoYFecha.FechaCreacion = dto.Fecha;
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.CreadorPorU = dto.Usuario;
            entity.Borrado = false;
            return entity;
        }

        public override Categoria UpdateDtoToEntity(UpdateCategoriaDto dto, Categoria entity)
        {
            entity.EstadoYFecha.Estado = dto.Estado;
            entity.Descripcion = dto.Descripcion;
            entity.FechaModificacion = dto.Fecha;
            entity.UsuarioMod = dto.Usuario;
            return entity;
        }
    }
}
