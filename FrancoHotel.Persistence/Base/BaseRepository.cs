using System.Formats.Tar;
using System.Linq.Expressions;
using FrancoHotel.Domain.Repository;
using FrancoHotel.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using FrancoHotel.Domain.Base;
using Microsoft.EntityFrameworkCore.Internal;

namespace FrancoHotel.Persistence.Base
{
    public abstract class BaseRepository<TEntity, Ttype> : IBaseRepository<TEntity, Ttype> where TEntity : class
    {
        private readonly HotelContext _context;
        private DbSet<TEntity> Entity { get; set; }

        protected BaseRepository(HotelContext context)
        {
            _context = context;
            Entity = _context.Set<TEntity>();
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await Entity.AnyAsync(filter);
        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new OperationResult();
            try
            {
                var Datos = Entity.Where(filter).ToListAsync();
                result.Data = Datos;
            }
            catch (Exception)
            {

                result.Success = false;
                result.Message = "Ocurrio un error guardando los datos.";
            }
            return result;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        { 
            return await Entity.ToListAsync();
        }

        public virtual async Task<TEntity> GetEntityByIdAsync(Ttype id)
        {
            return await Entity.FindAsync(id);
        }

        public virtual async Task<OperationResult> SaveEntityAsync(TEntity entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                Entity.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrio un error guardando los datos.";
            }
            return result;
        }

        public virtual async Task<OperationResult> UpdateEntityAsync(TEntity entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                Entity.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrio un error guardando los datos.";
            }
            return result;
        }
    }
}
