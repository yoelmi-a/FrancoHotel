
using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.TarifasDto;
using FrancoHotel.Application.Dtos.TarifasDtos;

namespace FrancoHotel.Application.Interfaces
{
    public interface ITarifasService : IBaseService<RemoveTarifasDto, SaveTarifasDtos, UpdateTarifasDto>
    {
    }
}
