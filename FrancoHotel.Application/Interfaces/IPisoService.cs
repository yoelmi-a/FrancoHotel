using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Application.Interfaces
{
    public interface IPisoService : IBaseService<SavePisoDto, UpdatePisoDto, RemovePisoDto>
    {
        Task<OperationResult> GetPisoByEstado(bool? estado);
    }
}
