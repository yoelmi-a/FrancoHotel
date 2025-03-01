using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;
using FrancoHotel.Models.Models;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IPisoRepository : IBaseRepository<Piso, int>
    {
        Task<List<PisoModel>> GetPisoByEstado(bool? estado);
    }
}
