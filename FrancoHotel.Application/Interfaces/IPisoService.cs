using System.Linq.Expressions;
using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Interfaces
{
    public interface IPisoService : IBaseService<SavePisoDto, UpdatePisoDto, RemovePisoDto>
    {
    }
}
