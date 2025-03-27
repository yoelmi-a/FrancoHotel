using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion, int>
    {
        Task<bool> GetHabitacionInPisoBooked(int idPiso);
    }
}
