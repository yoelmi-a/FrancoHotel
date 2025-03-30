using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.CategoriaDtos;

namespace FrancoHotel.Application.Interfaces
{
    public interface ICategoriaService : IBaseService<SaveCategoriaDto, UpdateCategoriaDto, RemoveCategoriaDto>
    {
    }
}
