using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.HabitacionDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;

namespace FrancoHotel.Application.Services
{
    public class HabitacionService : IHabitacionService
    {
        public Task<OperationResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(RemoveHabitacionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Save(SaveHabitacionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(UpdateHabitacionDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
