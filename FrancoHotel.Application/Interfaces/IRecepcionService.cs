
using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.RecepcionDtos;

namespace FrancoHotel.Application.Interfaces
{
    public interface IRecepcionService : IBaseService<SaveRecepcionDto, UpdateRecepcionDto, RemoveRecepcionDto>
    {
    }
}
