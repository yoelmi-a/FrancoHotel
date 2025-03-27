using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.PisoDtos;

namespace FrancoHotel.Application.Interfaces
{
    public interface IPisoService : IBaseService<SavePisoDto, UpdatePisoDto, RemovePisoDto>
    {
    }
}
