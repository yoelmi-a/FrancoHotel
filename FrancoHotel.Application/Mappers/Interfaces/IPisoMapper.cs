using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IPisoMapper : IBaseMapper<SavePisoDto, UpdatePisoDto, RemovePisoDto, Piso>
    {
    }
}
