using System.Linq.Expressions;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Repository
{
    /// <summary>
    /// Interfaz de herencia para los repositorios.
    /// </summary>
    /// <typeparam name="TEntity">Entidad</typeparam>
    /// <typeparam name="Ttype">El Tipo de dato del primmary Key para realizar consulta.</typeparam>
    public interface IBaseRepository<TEntity, Ttype> where TEntity : class
    {
        Task SaveEntityAsync(TEntity entity);
        Task UpdateEntityAsync(TEntity entity);
        Task DeleteEntityAsync(TEntity entity);
        Task<TEntity> GetEntityByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<OperationResult> GetAll(Expression<Func<TEntity, bool>> filter);
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
    }
}
