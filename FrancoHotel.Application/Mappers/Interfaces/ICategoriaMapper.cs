using FrancoHotel.Application.Dtos.CategoriaDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface ICategoriaMapper : IBaseMapper<SaveCategoriaDto, UpdateCategoriaDto, RemoveCategoriaDto, Categoria>
    {
    }
}
