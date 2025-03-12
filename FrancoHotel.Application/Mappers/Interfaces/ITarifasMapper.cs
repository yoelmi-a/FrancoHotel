
using FrancoHotel.Application.Dtos.TarifasDto;
using FrancoHotel.Application.Dtos.TarifasDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface ITarifasMapper : IBaseMapper<SaveTarifasDtos, UpdateTarifasDto, RemoveTarifasDto, Tarifas>
    {
    }
}
