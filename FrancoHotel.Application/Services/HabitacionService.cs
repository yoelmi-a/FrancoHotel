using System.Linq.Expressions;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;

namespace FrancoHotel.Application.Services
{
    public class HabitacionService : IHabitacionRepository
    {
        public Task<bool> Exists(Expression<Func<Habitacion, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Habitacion>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAllAsync(Expression<Func<Habitacion, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Habitacion?> GetEntityByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> RemoveEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> SaveEntityAsync(Habitacion entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateEntityAsync(Habitacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
