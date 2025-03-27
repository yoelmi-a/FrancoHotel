using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.ServiciosDto;

namespace FrancoHotel.Application.Interfaces
{
    public interface IServiciosService : IBaseService<SaveServiciosDto, UpdateServiciosDto, RemoveServiciosDto>
    {
    }
}
