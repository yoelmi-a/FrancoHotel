using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.ServiciosDto;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Application.Interfaces
{
    public interface IServiciosService : IBaseService<SaveServiciosDto, UpdateServiciosDto, RemoveServiciosDto>
    {
    }
}
