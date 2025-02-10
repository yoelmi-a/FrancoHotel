using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;

namespace FrancoHotel.Persistence.Repositories
{
    public class HabitacionRepository : BaseRepository<Habitacion, int>, IHabitacionRepository
    {
        private readonly HotelContext context;

        public HabitacionRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }

        public override Task<OperationResult> SaveEntityAsync(Habitacion entity)
        {
            ///Agregar validaciones correspondientes. //
            ///
            return base.SaveEntityAsync(entity);
        }
    }
}
